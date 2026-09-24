using FoodChow.Application.Interfaces;
using FoodChow.Application.Security;
using FoodChow.Application.Services;
using FoodChow.Domain.Common;
using FoodChow.Infrastructure.Auth;
using FoodChow.Infrastructure.DALC;
using FoodChow.Infrastructure.Repositories;
using FoodChow.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Load config globally
AppGlobals.Initialize(builder.Configuration);

// Add services
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new FoodChow.API.Converters.FlexibleStringConverter());
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FoodChow API — Enterprise Restaurant & Ordering Backend",
        Version = "v1.0",
        Description = "Production-grade RESTful API built on .NET 10 Clean Architecture with Dapper, MySQL Stored Procedures, and JWT Bearer Security. Developed for the FoodChow Restaurant Operating System."
    });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Paste ONLY the JWT access token."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = new List<string>()
    });
});

// ===================== JWT Authentication =====================
var jwtKey = builder.Configuration["Jwt:Key"]
    ?? throw new InvalidOperationException("Jwt:Key is missing from configuration.");

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30)
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<IAuthService, FoodChow.Application.Services.AuthService>();

// MySQL DALC
builder.Services.AddScoped<MySqlDalc>();


// Product
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ProductService>();

// Shop
builder.Services.AddScoped<IShopRepository, ShopRepository>();
builder.Services.AddScoped<ShopService>();



// Coupon
builder.Services.AddScoped<ICouponMasterRepository, CouponMasterRepository>();
builder.Services.AddScoped<CouponMasterService>();

// AffiniaPayment
builder.Services.AddScoped<IAffiniaPaymentRepository, AffiniaPaymentRepository>();
builder.Services.AddScoped<AffiniaPaymentService>();

// BulkEdit
builder.Services.AddScoped<IBulkEditRepository, BulkEditRepository>();
builder.Services.AddScoped<BulkEditService>();

// FoodUserMaster
builder.Services.AddScoped<IFoodUserMasterRepository, FoodUserMasterRepository>();
builder.Services.AddScoped<FoodUserMasterService>();

// KdsTerminalsSetting
builder.Services.AddScoped<IKdsTerminalsSettingRepository, KdsTerminalsSettingRepository>();
builder.Services.AddScoped<KdsTerminalsSettingService>();

// LalaMove
builder.Services.AddScoped<ILalaMoveRepository, LalaMoveRepository>();
builder.Services.AddScoped<LalaMoveService>();

// PaymentConfiguration
builder.Services.AddScoped<IPaymentConfigurationRepository, PaymentConfigurationRepository>();
builder.Services.AddScoped<PaymentConfigurationService>();

//PorterConfiguration
builder.Services.AddScoped<IPorterConfigurationRepository, PorterConfigurationRepository>();
builder.Services.AddScoped<PorterConfigurationService>();

//PricingPlan
builder.Services.AddScoped<IPricingPlanRepository, PricingPlanRepository>();
builder.Services.AddScoped<PricingPlanService>();

// Printer
builder.Services.AddScoped<IPrinterRepository, PrinterRepository>();
builder.Services.AddScoped<PrinterService>();

// ReportMaster
builder.Services.AddScoped<IReportMasterRepository, ReportMasterRepository>();
builder.Services.AddScoped<ReportMasterService>();

//RestaurantProfile
builder.Services.AddScoped<IRestaurantProfileRepository, RestaurantProfileRepository>();
builder.Services.AddScoped<RestaurantProfileService>();

// StoreTimingsMaster
builder.Services.AddScoped<IStoreTimingsMasterRepository, StoreTimingsMasterRepository>();
builder.Services.AddScoped<StoreTimingsMasterService>();

//TaxMaster
builder.Services.AddScoped<ITaxMasterRepository, TaxMasterRepository>();
builder.Services.AddScoped<TaxMasterService>();

//UserMaster
builder.Services.AddScoped<IUserMasterRepository, UserMasterRepository>();
builder.Services.AddScoped<UserMasterService>();

//StripeConnect
builder.Services.AddScoped<StripeConnectService>();
builder.Services.AddScoped<IStripeConnectRepository, StripeConnectRepository>();

// MasterReason
builder.Services.AddScoped<IMasterReasonRepository, MasterReasonRepository>();
builder.Services.AddScoped<MasterReasonService>();

//Food Preference
builder.Services.AddScoped<IFoodPreferenceRepository, FoodPreferenceRepository>();
builder.Services.AddScoped<FoodPreferenceService>();

//Preference option
builder.Services.AddScoped<IPreferenceOptionRepository, PreferenceOptionRepository>();
builder.Services.AddScoped<PreferenceOptionService>();

//table
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<TableService>();

//reservation
builder.Services.AddScoped<IReservationRequestRepository, ReservationRequestRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddScoped<ReservationRequestService>();
builder.Services.AddScoped<ReservationService>();

//doordashdevlivery
builder.Services.AddScoped<IDoorDashDeliveryRepository, DoorDashDeliveryRepository>();
builder.Services.AddScoped<DoorDashDeliveryService>();

//deliveryZone
builder.Services.AddScoped<IDeliveryZoneRepository, DeliveryZoneRepository>();
builder.Services.AddScoped<DeliveryZoneService>();

//dashboard
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<DashboardService>();

//driver
builder.Services.AddScoped<IDriverRepository, DriverRepository>();
builder.Services.AddScoped<DriverService>();

//Invoice
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<InvoiceService>();


//Order
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<OrderService>();

//Order support services 
builder.Services.AddScoped<FoodChow.Application.Interfaces.IShopTimeZoneService, FoodChow.Infrastructure.Services.ShopTimeZoneService>();
builder.Services.AddScoped<FoodChow.Application.Interfaces.IShopCurrencyService, FoodChow.Infrastructure.Services.ShopCurrencyService>();
builder.Services.AddScoped<FoodChow.Application.Interfaces.IOrderNotificationService, FoodChow.Infrastructure.Services.OrderNotificationService>();
builder.Services.AddScoped<FoodChow.Application.Interfaces.IOrderEmailService, FoodChow.Infrastructure.Services.OrderEmailService>();
builder.Services.AddHttpClient();
//Offer
builder.Services.AddScoped<IOfferRepository, OfferRepository>();
builder.Services.AddScoped<OfferService>();

//master
builder.Services.AddScoped<IMasterRepository, MasterRepository>();
builder.Services.AddScoped<MasterService>();

//menu
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<MenuService>();

//category
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<CategoryService>();

//refer and earn
builder.Services.AddScoped<IReferAndEarnRepository, ReferAndEarnRepository>();
builder.Services.AddScoped<ReferAndEarnService>();

//restaurantRefferEarn
builder.Services.AddScoped<IRestaurantReferEarnRepository, RestaurantReferEarnRepository>();
builder.Services.AddScoped<RestaurantReferEarnService>();

//restauranttree
builder.Services.AddScoped<IRestaurantTreeRepository, RestaurantTreeRepository>();
builder.Services.AddScoped<RestaurantTreeService>();

//stripe
builder.Services.AddScoped<IStripeRepository, StripeRepository>();
builder.Services.AddScoped<StripeService>();

//uberdirect
builder.Services.AddScoped<IUberDirectRepository, UberDirectRepository>();
builder.Services.AddScoped<UberDirectService>();

//wallet
builder.Services.AddScoped<IWalletRepository, WalletRepository>();
builder.Services.AddScoped<WalletService>();

//whatsapp
builder.Services.AddScoped<IWhatsappRepository, WhatsappRepository>();
builder.Services.AddScoped<WhatsAppMasterService>();

//widgetSettings
builder.Services.AddScoped<IWidgetSettingsRepository, WidgetSettingsRepository>();
builder.Services.AddScoped<WidgetSettingsService>();

//yocoPayment
builder.Services.AddScoped<IYocoPaymentRepository, YocoPaymentRepository>();
builder.Services.AddScoped<YocoPaymentService>();

//marketing
builder.Services.AddScoped<IMarketingMaterialRepository, MarketingMaterialRepository>();
builder.Services.AddScoped<MarketingMaterialService>();

//Health check (vendor/apikey module)
builder.Services.AddScoped<IHealthRepository, HealthRepository>();
builder.Services.AddScoped<HealthService>();

//Meta (area serviceability + reference data)
builder.Services.AddScoped<IMetaRepository, MetaRepository>();
builder.Services.AddScoped<MetaService>();

// FareEstimate

builder.Services.AddScoped<IFareEstimateRepository, FareEstimateRepository>();
builder.Services.AddScoped<FareEstimateService>();

//RiderAvailability
builder.Services.AddScoped<IRiderAvailabilityRepository, RiderAvailabilityRepository>();
builder.Services.AddScoped<RiderAvailabilityService>();

//OrderCreate
builder.Services.AddScoped<IOrderCreateRepository, OrderCreateRepository>();
builder.Services.AddScoped<OrderCreateService>();

//OrderCancel
builder.Services.AddScoped<IOrderCancelRepository, OrderCancelRepository>();
builder.Services.AddScoped<OrderCancelService>();

//OrderTrack
builder.Services.AddScoped<IOrderTrackRepository, OrderTrackRepository>();
builder.Services.AddScoped<OrderTrackService>();

//WalletBalance
builder.Services.AddScoped<IWalletBalanceRepository, WalletBalanceRepository>();
builder.Services.AddScoped<WalletBalanceService>();


builder.Services.Configure<Microsoft.AspNetCore.Builder.ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor 
                             | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedProto;
    options.KnownIPNetworks.Clear();
    options.KnownProxies.Clear();
});

var app = builder.Build();

app.UseForwardedHeaders();

// Swagger
app.UseSwagger();

app.UseSwaggerUI();

// Static files (uploaded images served from wwwroot/)
app.UseStaticFiles();

// HTTPS (Cloud Run handles TLS termination at load balancer; skip internal redirection in Production)
if (!app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

// IMPORTANT: Authentication must run before Authorization, and both must run
// before MapControllers(), otherwise [Authorize] attributes are silently ignored.
app.UseAuthentication();
app.UseAuthorization();

// Map Controllers
app.MapControllers();

app.Run();

// Exposes Program for WebApplicationFactory<Program> in integration tests.
public partial class Program { }