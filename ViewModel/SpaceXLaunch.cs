
using System;
using System.Collections.Generic;

namespace AstroAPI.ViewModels
{
    /*
        Generated here: http://json2csharp.com/#
        from: https://api.spacexdata.com/v3/launches/upcoming
     */
    public class Core
    {
        public object core_serial { get; set; }
        public object flight { get; set; }
        public int? block { get; set; }
        public bool? gridfins { get; set; }
        public bool? legs { get; set; }
        public bool? reused { get; set; }
        public object land_success { get; set; }
        public bool? landing_intent { get; set; }
        public string landing_type { get; set; }
        public string landing_vehicle { get; set; }
    }

    public class FirstStage
    {
        public List<Core> cores { get; set; }
    }

    public class OrbitParams
    {
        public string reference_system { get; set; }
        public string regime { get; set; }
        public double? longitude { get; set; }
        public object semi_major_axis_km { get; set; }
        public object eccentricity { get; set; }
        public object periapsis_km { get; set; }
        public object apoapsis_km { get; set; }
        public object inclination_deg { get; set; }
        public object period_min { get; set; }
        public double? lifespan_years { get; set; }
        public object epoch { get; set; }
        public object mean_motion { get; set; }
        public object raan { get; set; }
        public object arg_of_pericenter { get; set; }
        public object mean_anomaly { get; set; }
    }

    public class Payload
    {
        public string payload_id { get; set; }
        public List<object> norad_id { get; set; }
        public bool? reused { get; set; }
        public List<string> customers { get; set; }
        public string nationality { get; set; }
        public string manufacturer { get; set; }
        public string payload_type { get; set; }
        public int? payload_mass_kg { get; set; }
        public double? payload_mass_lbs { get; set; }
        public string orbit { get; set; }
        public OrbitParams orbit_params { get; set; }
    }

    public class SecondStage
    {
        public int? block { get; set; }
        public List<Payload> payloads { get; set; }
    }

    public class Fairings
    {
        public bool? reused { get; set; }
        public bool? recovery_attempt { get; set; }
        public bool? recovered { get; set; }
        public object ship { get; set; }
    }

    public class Rocket
    {
        public string rocket_id { get; set; }
        public string rocket_name { get; set; }
        public string rocket_type { get; set; }
        public FirstStage first_stage { get; set; }
        public SecondStage second_stage { get; set; }
        public Fairings fairings { get; set; }
    }

    public class Telemetry
    {
        public object flight_club { get; set; }
    }

    public class LaunchSite
    {
        public string site_id { get; set; }
        public string site_name { get; set; }
        public string site_name_long { get; set; }
    }

    public class Links
    {
        public object mission_patch { get; set; }
        public object mission_patch_small { get; set; }
        public string reddit_campaign { get; set; }
        public object reddit_launch { get; set; }
        public object reddit_recovery { get; set; }
        public object reddit_media { get; set; }
        public object presskit { get; set; }
        public object article_link { get; set; }
        public object wikipedia { get; set; }
        public object video_link { get; set; }
        public List<object> flickr_images { get; set; }
    }

    public class SpaceXLaunch
    {
        public int? flight_number { get; set; }
        public string mission_name { get; set; }
        public List<object> mission_id { get; set; }
        public string launch_year { get; set; }
        public int? launch_date_unix { get; set; }
        public DateTime launch_date_utc { get; set; }
        public DateTime launch_date_local { get; set; }
        public bool is_tentative { get; set; }
        public string tentative_max_precision { get; set; }
        public Rocket rocket { get; set; }
        public List<object> ships { get; set; }
        public Telemetry telemetry { get; set; }
        public LaunchSite launch_site { get; set; }
        public object launch_success { get; set; }
        public Links links { get; set; }
        public string details { get; set; }
        public bool upcoming { get; set; }
        public object static_fire_date_utc { get; set; }
        public object static_fire_date_unix { get; set; }
    }
}