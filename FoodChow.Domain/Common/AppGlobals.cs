namespace FoodChow.Domain.Common
{
    /// <summary>
    /// Global static state. Call AppGlobals.Initialize(config) once in Program.cs.
    /// Read from any layer — no DI needed.
    /// </summary>
    public static class AppGlobals
    {
        // ── App Info ────────────────────────────────────────────────────────────
        public static string AppName { get; private set; } = "FoodChow";
        public static string AppVersion { get; private set; } = "1.0.0";
        public static string Environment { get; private set; } = "Development";

        // ── Database ─────────────────────────────────────────────────────────────
        public static string MySqlConnectionString { get; private set; } = string.Empty;

        // ── JWT ──────────────────────────────────────────────────────────────────
        public static string JwtKey { get; private set; } = string.Empty;
        public static string JwtIssuer { get; private set; } = string.Empty;
        public static string JwtAudience { get; private set; } = string.Empty;
        public static int JwtExpiryHours { get; private set; } = 2;

        // ── Feature Flags ────────────────────────────────────────────────────────
        public static bool EnableSwagger { get; private set; } = true;
        public static bool EnableDetailedErrors { get; private set; } = false;

        // ── Custom / Extendable ──────────────────────────────────────────────────
        // Add your own static vars here. Use Set() for runtime changes.
        private static readonly Dictionary<string, string> _custom = new();

        /// <summary>
        /// Load all values from IConfiguration at startup.
        /// Call once in Program.cs before app.Build().
        /// </summary>
        public static void Initialize(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            AppName    = config["App:Name"]    ?? AppName;
            AppVersion = config["App:Version"] ?? AppVersion;
            Environment = config["App:Environment"] ?? AppGlobals.Environment;

            MySqlConnectionString = config["ConnectionStrings:MySql"] ?? string.Empty;

            JwtKey       = config["Jwt:Key"]       ?? string.Empty;
            JwtIssuer    = config["Jwt:Issuer"]    ?? string.Empty;
            JwtAudience  = config["Jwt:Audience"]  ?? string.Empty;
            JwtExpiryHours = int.TryParse(config["Jwt:ExpiryHours"], out var h) ? h : JwtExpiryHours;

            EnableSwagger        = bool.TryParse(config["Flags:EnableSwagger"], out var s) ? s : EnableSwagger;
            EnableDetailedErrors = bool.TryParse(config["Flags:EnableDetailedErrors"], out var d) ? d : EnableDetailedErrors;
        }

        // ── Custom key-value store ────────────────────────────────────────────────

        /// <summary>Set any custom global value at runtime.</summary>
        public static void Set(string key, string value) => _custom[key] = value;

        /// <summary>Get custom value. Returns null if key not found.</summary>
        public static string? Get(string key) => _custom.TryGetValue(key, out var v) ? v : null;

        /// <summary>Check if custom key exists.</summary>
        public static bool Has(string key) => _custom.ContainsKey(key);
    }
}
