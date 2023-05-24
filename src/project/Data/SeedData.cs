using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WatchParty.Data;

    /// <summary>
    /// Helper class to hold all the information we need to construct the users for this app.  Basically
    /// a union of WatchPartyUser and IdentityUser.  Not great to have to duplicate this data but it is only for one-time seeding
    /// of the databases.  Does NOT hold passwords since we need to store those in a secret location.
    /// </summary>
public class UserInfoData
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool EmailConfirmed { get; set; } = true;
}

public class SeedData
{ 
    /// <summary>
    /// Data to be used to seed the WatchPartyUsers and ASPNetUsers tables
    /// </summary>
    public static readonly UserInfoData[] UserSeedData = new UserInfoData[]
    {
        new UserInfoData { UserName = "SophieBennett", Email = "sophiebennett@example.com", FirstName = "Sophie", LastName = "Bennett" },
        new UserInfoData { UserName = "DanielScott", Email = "danielscott@example.com", FirstName = "Daniel", LastName = "Scott" },
        new UserInfoData { UserName = "AveryMurphy", Email = "averymurphy@example.com", FirstName = "Avery", LastName = "Murphy" },
        new UserInfoData { UserName = "LeoRivera", Email = "leorivera@example.com", FirstName = "Leo", LastName = "Rivera" },
        new UserInfoData { UserName = "ZoeGomez", Email = "zoegomez@example.com", FirstName = "Zoe", LastName = "Gomez" },
        new UserInfoData { UserName = "NathanStewart", Email = "nathanstewart@example.com", FirstName = "Nathan", LastName = "Stewart" },
        new UserInfoData { UserName = "AudreyWard", Email = "audreyward@example.com", FirstName = "Audrey", LastName = "Ward" },
        new UserInfoData { UserName = "ElijahPowell", Email = "elijahpowell@example.com", FirstName = "Elijah", LastName = "Powell" },
        new UserInfoData { UserName = "MiaSimmons", Email = "miasimmons@example.com", FirstName = "Mia", LastName = "Simmons" },
        new UserInfoData { UserName = "BenjaminRoss", Email = "benjaminross@example.com", FirstName = "Benjamin", LastName = "Ross" },
        new UserInfoData { UserName = "HarperAnderson", Email = "harperanderson@example.com", FirstName = "Harper", LastName = "Anderson" },
        new UserInfoData { UserName = "EthanTurner", Email = "ethanturner@example.com", FirstName = "Ethan", LastName = "Turner" },
        new UserInfoData { UserName = "AddisonMitchell", Email = "addisonmitchell@example.com", FirstName = "Addison", LastName = "Mitchell" },
        new UserInfoData { UserName = "SamuelJenkins", Email = "samueljenkins@example.com", FirstName = "Samuel", LastName = "Jenkins" },
        new UserInfoData { UserName = "GraceParker", Email = "graceparker@example.com", FirstName = "Grace", LastName = "Parker" },
        new UserInfoData { UserName = "IsaacCarter", Email = "isaaccarter@example.com", FirstName = "Isaac", LastName = "Carter" },
        new UserInfoData { UserName = "LunaEvans", Email = "lunaevans@example.com", FirstName = "Luna", LastName = "Evans" },
        new UserInfoData { UserName = "CalebCooper", Email = "calebcooper@example.com", FirstName = "Caleb", LastName = "Cooper" },
        new UserInfoData { UserName = "MilaHarrison", Email = "milaharrison@example.com", FirstName = "Mila", LastName = "Harrison" },
        new UserInfoData { UserName = "OwenReed", Email = "owenreed@example.com", FirstName = "Owen", LastName = "Reed" },
        new UserInfoData { UserName = "EmilySmith", Email = "emilysmith@example.com", FirstName = "Emily", LastName = "Smith" },
        new UserInfoData { UserName = "JacobJohnson", Email = "jacobjohnson@example.com", FirstName = "Jacob", LastName = "Johnson" },
        new UserInfoData { UserName = "OliviaWilliams", Email = "oliviawilliams@example.com", FirstName = "Olivia", LastName = "Williams" },
        new UserInfoData { UserName = "WilliamBrown", Email = "williambrown@example.com", FirstName = "William", LastName = "Brown" },
        new UserInfoData { UserName = "AvaJones", Email = "avajones@example.com", FirstName = "Ava", LastName = "Jones" },
        new UserInfoData { UserName = "LiamTaylor", Email = "liamtaylor@example.com", FirstName = "Liam", LastName = "Taylor" },
        new UserInfoData { UserName = "SophiaDavis", Email = "sophiadavis@example.com", FirstName = "Sophia", LastName = "Davis" },
        new UserInfoData { UserName = "JacksonMiller", Email = "jacksonmiller@example.com", FirstName = "Jackson", LastName = "Miller" },
        new UserInfoData { UserName = "EmmaWilson", Email = "emmawilson@example.com", FirstName = "Emma", LastName = "Wilson" },
        new UserInfoData { UserName = "AidenAnderson", Email = "aidenanderson@example.com", FirstName = "Aiden", LastName = "Anderson" },
        new UserInfoData { UserName = "OliverThomas", Email = "oliverthomas@example.com", FirstName = "Oliver", LastName = "Thomas" },
        new UserInfoData { UserName = "AveryMartinez", Email = "averymartinez@example.com", FirstName = "Avery", LastName = "Martinez" },
        new UserInfoData { UserName = "ElijahRobinson", Email = "elijahrobinson@example.com", FirstName = "Elijah", LastName = "Robinson" },
        new UserInfoData { UserName = "CharlotteClark", Email = "charlotteclark@example.com", FirstName = "Charlotte", LastName = "Clark" },
        new UserInfoData { UserName = "MasonHernandez", Email = "masonhernandez@example.com", FirstName = "Mason", LastName = "Hernandez" },
        new UserInfoData { UserName = "AmeliaHill", Email = "ameliahill@example.com", FirstName = "Amelia", LastName = "Hill" },
        new UserInfoData { UserName = "JamesWalker", Email = "jameswalker@example.com", FirstName = "James", LastName = "Walker" },
        new UserInfoData { UserName = "LilyGonzalez", Email = "lilygonzalez@example.com", FirstName = "Lily", LastName = "Gonzalez" },
        new UserInfoData { UserName = "BenjaminYoung", Email = "benjaminyoung@example.com", FirstName = "Benjamin", LastName = "Young" },
        new UserInfoData { UserName = "MiaAllen", Email = "miaallen@example.com", FirstName = "Mia", LastName = "Allen" },
        new UserInfoData { UserName = "HenryHall", Email = "henryhall@example.com", FirstName = "Henry", LastName = "Hall" },
        new UserInfoData { UserName = "EvelynLee", Email = "evelynlee@example.com", FirstName = "Evelyn", LastName = "Lee" },
        new UserInfoData { UserName = "SebastianLewis", Email = "sebastianlewis@example.com", FirstName = "Sebastian", LastName = "Lewis" },
        new UserInfoData { UserName = "AriaScott", Email = "ariascott@example.com", FirstName = "Aria", LastName = "Scott" },
        new UserInfoData { UserName = "JackWright", Email = "jackwright@example.com", FirstName = "Jack", LastName = "Wright" },
        new UserInfoData { UserName = "HarperGreen", Email = "harpergreen@example.com", FirstName = "Harper", LastName = "Green" },
        new UserInfoData { UserName = "RyanAdams", Email = "ryanadams@example.com", FirstName = "Ryan", LastName = "Adams" },
        new UserInfoData { UserName = "SofiaKing", Email = "sofiaking@example.com", FirstName = "Sofia", LastName = "King" },
        new UserInfoData { UserName = "LeoBaker", Email = "leobaker@example.com", FirstName = "Leo", LastName = "Baker" },
        new UserInfoData { UserName = "AubreyCarter", Email = "aubreycarter@example.com", FirstName = "Aubrey", LastName = "Carter" },
        new UserInfoData { UserName = "JulianGarcia", Email = "juliangarcia@example.com", FirstName = "Julian", LastName = "Garcia" },
        new UserInfoData { UserName = "MilaRivera", Email = "milarivera@example.com", FirstName = "Mila", LastName = "Rivera" },
        new UserInfoData { UserName = "ChristopherCooper", Email = "christophercooper@example.com", FirstName = "Christopher", LastName = "Cooper" },
        new UserInfoData { UserName = "PenelopeRoss", Email = "penelopeross@example.com", FirstName = "Penelope", LastName = "Ross" },
        new UserInfoData { UserName = "LukeMorgan", Email = "lukemorgan@example.com", FirstName = "Luke", LastName = "Morgan" },
        new UserInfoData { UserName = "LaylaReed", Email = "laylareed@example.com", FirstName = "Layla", LastName = "Reed" },
        new UserInfoData { UserName = "DanielBailey", Email = "danielbailey@example.com", FirstName = "Daniel", LastName = "Bailey" },
        new UserInfoData { UserName = "ScarlettTurner", Email = "scarlettturner@example.com", FirstName = "Scarlett", LastName = "Turner" },
        new UserInfoData { UserName = "DavidParker", Email = "davidparker@example.com", FirstName = "David", LastName = "Parker" },
        new UserInfoData { UserName = "VictoriaCook", Email = "victoriacook@example.com", FirstName = "Victoria", LastName = "Cook" },
        new UserInfoData { UserName = "JosephGomez", Email = "josephgomez@example.com", FirstName = "Joseph", LastName = "Gomez" },
        new UserInfoData { UserName = "NoraMorris", Email = "noramorris@example.com", FirstName = "Nora", LastName = "Morris" },
        new UserInfoData { UserName = "SamuelSanders", Email = "samuelsanders@example.com", FirstName = "Samuel", LastName = "Sanders" },
        new UserInfoData { UserName = "HannahJames", Email = "hannahjames@example.com", FirstName = "Hannah", LastName = "James" },
        new UserInfoData { UserName = "ChristopherPowell", Email = "christopherpowell@example.com", FirstName = "Christopher", LastName = "Powell" },
        new UserInfoData { UserName = "GraceBarnes", Email = "gracebarnes@example.com", FirstName = "Grace", LastName = "Barnes" },
        new UserInfoData { UserName = "AndrewGonzales", Email = "andrewgonzales@example.com", FirstName = "Andrew", LastName = "Gonzales" },
        new UserInfoData { UserName = "EllaButler", Email = "ellabutler@example.com", FirstName = "Ella", LastName = "Butler" },
        new UserInfoData { UserName = "SamuelSimmons", Email = "samuelsimmons@example.com", FirstName = "Samuel", LastName = "Simmons" },
        new UserInfoData { UserName = "StellaFoster", Email = "stellafoster@example.com", FirstName = "Stella", LastName = "Foster" },
        new UserInfoData { UserName = "DavidGray", Email = "davidgray@example.com", FirstName = "David", LastName = "Gray" },
        new UserInfoData { UserName = "NatalieWashington", Email = "nataliewashington@example.com", FirstName = "Natalie", LastName = "Washington" },
        new UserInfoData { UserName = "HenryRogers", Email = "henryrogers@example.com", FirstName = "Henry", LastName = "Rogers" },
        new UserInfoData { UserName = "MayaPerez", Email = "mayaperez@example.com", FirstName = "Maya", LastName = "Perez" },
        new UserInfoData { UserName = "NathanBrooks", Email = "nathanbrooks@example.com", FirstName = "Nathan", LastName = "Brooks" },
        new UserInfoData { UserName = "AaliyahPrice", Email = "aaliyahprice@example.com", FirstName = "Aaliyah", LastName = "Price" },
        new UserInfoData { UserName = "NicholasLong", Email = "nicholaslong@example.com", FirstName = "Nicholas", LastName = "Long" },
        new UserInfoData { UserName = "ClaireSanders", Email = "clairesanders@example.com", FirstName = "Claire", LastName = "Sanders" },
        new UserInfoData { UserName = "LeoCollins", Email = "leocollins@example.com", FirstName = "Leo", LastName = "Collins" },
        new UserInfoData { UserName = "BrooklynBell", Email = "brooklynbell@example.com", FirstName = "Brooklyn", LastName = "Bell" },
        new UserInfoData { UserName = "IsaacHenderson", Email = "isachenderson@example.com", FirstName = "Isaac", LastName = "Henderson" },
        new UserInfoData { UserName = "EleanorReed", Email = "eleanorreed@example.com", FirstName = "Eleanor", LastName = "Reed" },
        new UserInfoData { UserName = "CarterGibson", Email = "cartergibson@example.com", FirstName = "Carter", LastName = "Gibson" },
        new UserInfoData { UserName = "NovaFisher", Email = "novafisher@example.com", FirstName = "Nova", LastName = "Fisher" },
        new UserInfoData { UserName = "SamuelWright", Email = "samuelwright@example.com", FirstName = "Samuel", LastName = "Wright" },
        new UserInfoData { UserName = "LucySanders", Email = "lucysanders@example.com", FirstName = "Lucy", LastName = "Sanders" },
        new UserInfoData { UserName = "AdrianMorris", Email = "adrianmorris@example.com", FirstName = "Adrian", LastName = "Morris" },
        new UserInfoData { UserName = "StellaHarrison", Email = "stellaharrison@example.com", FirstName = "Stella", LastName = "Harrison" },
        new UserInfoData { UserName = "GabrielPrice", Email = "gabrielprice@example.com", FirstName = "Gabriel", LastName = "Price" },
        new UserInfoData { UserName = "GiannaFoster", Email = "giannafoster@example.com", FirstName = "Gianna", LastName = "Foster" },
        new UserInfoData { UserName = "IsaacMorgan", Email = "isaacmorgan@example.com", FirstName = "Isaac", LastName = "Morgan" },
        new UserInfoData { UserName = "ZoeWatson", Email = "zoewatson@example.com", FirstName = "Zoe", LastName = "Watson" },
        new UserInfoData { UserName = "JosiahCollins", Email = "josiahcollins@example.com", FirstName = "Josiah", LastName = "Collins" },
        new UserInfoData { UserName = "PaisleyWhite", Email = "paisleywhite@example.com", FirstName = "Paisley", LastName = "White" },
        new UserInfoData { UserName = "HudsonCox", Email = "hudsoncox@example.com", FirstName = "Hudson", LastName = "Cox" },
        new UserInfoData { UserName = "LeahRussell", Email = "leahrussell@example.com", FirstName = "Leah", LastName = "Russell" },
        new UserInfoData { UserName = "HarrisonHill", Email = "harrisonhill@example.com", FirstName = "Harrison", LastName = "Hill" },
        new UserInfoData { UserName = "SkylarWard", Email = "skylarward@example.com", FirstName = "Skylar", LastName = "Ward" },
        new UserInfoData { UserName = "DanielFoster", Email = "danielfoster@example.com", FirstName = "Daniel", LastName = "Foster" },
        new UserInfoData { UserName = "ZoeThompson", Email = "zoethompson@example.com", FirstName = "Zoe", LastName = "Thompson" },
        new UserInfoData { UserName = "AustinKelly", Email = "austinkelly@example.com", FirstName = "Austin", LastName = "Kelly" },
        new UserInfoData { UserName = "AuroraRoberts", Email = "auroraroberts@example.com", FirstName = "Aurora", LastName = "Roberts" },
        new UserInfoData { UserName = "SandraHart", Email = "SandraHart@example.com", FirstName = "Sandra", LastName = "Hart" },
        new UserInfoData { UserName = "CarsonDaniel", Email = "DanielCarson@example.com", FirstName = "Carson", LastName = "Daniel" },
        new UserInfoData { UserName = "PaigeCole", Email = "PaigeCole@example.com", FirstName = "Paige", LastName = "Cole" },
        new UserInfoData { UserName = "JaysonLawrence", Email = "jLawrence@example.com", FirstName = "Jayson", LastName = "Lawrence" },
        new UserInfoData { UserName = "GabrielGrant", Email = "gGabriel@example.com", FirstName = "Gabriel", LastName = "Grant" },
        new UserInfoData { UserName = "BradPorter", Email = "BradPorter@example.com", FirstName = "Brad", LastName = "Porter" },
        new UserInfoData { UserName = "JudsonCooke", Email = "JudsonCooke@example.com", FirstName = "Judson", LastName = "Cooke" },
        new UserInfoData { UserName = "SofiaCarpenter", Email = "CarpenterSofia@example.com", FirstName = "Sofia", LastName = "Carpenter" },
        new UserInfoData { UserName = "JosefMeyer", Email = "JosefMeyer@example.com", FirstName = "Josef", LastName = "Meyer" },
        new UserInfoData { UserName = "BobbieMcintyre", Email = "BobbieMcintyre@example.com", FirstName = "Bobbie", LastName = "Mcintyre" },
        new UserInfoData { UserName = "TaliaK", Email = "knott@example.com", FirstName = "Talia", LastName = "Knott" },
        new UserInfoData { UserName = "ZaydenC", Email = "clark@example.com", FirstName = "Zayden", LastName = "Clark" },
        new UserInfoData { UserName = "DavilaH", Email = "hareem@example.com", FirstName = "Hareem", LastName = "Davila" },
        new UserInfoData { UserName = "KrzysztofP", Email = "krzysztof@example.com", FirstName = "Krzysztof", LastName = "Ponce" }
    };
}

