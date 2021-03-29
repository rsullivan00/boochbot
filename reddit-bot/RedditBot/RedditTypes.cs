using System;
using System.Collections.Generic;
using System.Text;

namespace RedditBot.RedditTypes
{

    // These classes are generated from https://json2csharp.com/

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class MediaEmbed
    {
    }

    public class RedditVideo
    {
        public int BitrateKbps { get; set; }
        public string FallbackUrl { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string ScrubberMediaUrl { get; set; }
        public string DashUrl { get; set; }
        public int Duration { get; set; }
        public string HlsUrl { get; set; }
        public bool IsGif { get; set; }
        public string TranscodingStatus { get; set; }
    }

    public class SecureMedia
    {
        public RedditVideo RedditVideo { get; set; }
    }

    public class SecureMediaEmbed
    {
    }

    public class Gildings
    {
        public int Gid1 { get; set; }
    }

    public class ResizedIcon
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class ResizedStaticIcon
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class AllAwarding
    {
        public object GiverCoinReward { get; set; }
        public object SubredditId { get; set; }
        public bool IsNew { get; set; }
        public int DaysOfDripExtension { get; set; }
        public int CoinPrice { get; set; }
        public string Id { get; set; }
        public object PennyDonate { get; set; }
        public string AwardSubType { get; set; }
        public int CoinReward { get; set; }
        public string IconUrl { get; set; }
        public int DaysOfPremium { get; set; }
        public object TiersByRequiredAwardings { get; set; }
        public List<ResizedIcon> ResizedIcons { get; set; }
        public int IconWidth { get; set; }
        public int StaticIconWidth { get; set; }
        public object StartDate { get; set; }
        public bool IsEnabled { get; set; }
        public object AwardingsRequiredToGrantBenefits { get; set; }
        public string Description { get; set; }
        public object EndDate { get; set; }
        public int SubredditCoinReward { get; set; }
        public int Count { get; set; }
        public int StaticIconHeight { get; set; }
        public string Name { get; set; }
        public List<ResizedStaticIcon> ResizedStaticIcons { get; set; }
        public object IconFormat { get; set; }
        public int IconHeight { get; set; }
        public object PennyPrice { get; set; }
        public string AwardType { get; set; }
        public string StaticIconUrl { get; set; }
    }

    public class Media
    {
        public RedditVideo RedditVideo { get; set; }
    }

    public class Source
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Resolution
    {
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Variants
    {
    }

    public class Image
    {
        public Source Source { get; set; }
        public List<Resolution> Resolutions { get; set; }
        public Variants Variants { get; set; }
        public string Id { get; set; }
    }

    public class Preview
    {
        public List<Image> Images { get; set; }
        public bool Enabled { get; set; }
    }

    public class CrosspostParentList
    {
        public object ApprovedAtUtc { get; set; }
        public string Subreddit { get; set; }
        public string Selftext { get; set; }
        public string AuthorFullname { get; set; }
        public bool Saved { get; set; }
        public object ModReasonTitle { get; set; }
        public int Gilded { get; set; }
        public bool Clicked { get; set; }
        public string Title { get; set; }
        public List<object> LinkFlairRichtext { get; set; }
        public string SubredditNamePrefixed { get; set; }
        public bool Hidden { get; set; }
        public int Pwls { get; set; }
        public object LinkFlairCssClass { get; set; }
        public int Downs { get; set; }
        public int ThumbnailHeight { get; set; }
        public object TopAwardedType { get; set; }
        public bool HideScore { get; set; }
        public string Name { get; set; }
        public bool Quarantine { get; set; }
        public string LinkFlairTextColor { get; set; }
        public double UpvoteRatio { get; set; }
        public object AuthorFlairBackgroundColor { get; set; }
        public string SubredditType { get; set; }
        public int Ups { get; set; }
        public int TotalAwardsReceived { get; set; }
        public MediaEmbed MediaEmbed { get; set; }
        public int ThumbnailWidth { get; set; }
        public object AuthorFlairTemplateId { get; set; }
        public bool IsOriginalContent { get; set; }
        public List<object> UserReports { get; set; }
        public object SecureMedia { get; set; }
        public bool IsRedditMediaDomain { get; set; }
        public bool IsMeta { get; set; }
        public object Category { get; set; }
        public SecureMediaEmbed SecureMediaEmbed { get; set; }
        public object LinkFlairText { get; set; }
        public bool CanModPost { get; set; }
        public int Score { get; set; }
        public object ApprovedBy { get; set; }
        public bool AuthorPremium { get; set; }
        public string Thumbnail { get; set; }
        public bool Edited { get; set; }
        public object AuthorFlairCssClass { get; set; }
        public List<object> AuthorFlairRichtext { get; set; }
        public Gildings Gildings { get; set; }
        public string PostHint { get; set; }
        public object ContentCategories { get; set; }
        public bool IsSelf { get; set; }
        public object ModNote { get; set; }
        public double Created { get; set; }
        public string LinkFlairType { get; set; }
        public int Wls { get; set; }
        public object RemovedByCategory { get; set; }
        public object BannedBy { get; set; }
        public string AuthorFlairType { get; set; }
        public string Domain { get; set; }
        public bool AllowLiveComments { get; set; }
        public object SelftextHtml { get; set; }
        public object Likes { get; set; }
        public object SuggestedSort { get; set; }
        public object BannedAtUtc { get; set; }
        public string UrlOverriddenByDest { get; set; }
        public object ViewCount { get; set; }
        public bool Archived { get; set; }
        public bool NoFollow { get; set; }
        public bool IsCrosspostable { get; set; }
        public bool Pinned { get; set; }
        public bool Over18 { get; set; }
        public Preview Preview { get; set; }
        public List<AllAwarding> AllAwardings { get; set; }
        public List<object> Awarders { get; set; }
        public bool MediaOnly { get; set; }
        public bool CanGild { get; set; }
        public bool Spoiler { get; set; }
        public bool Locked { get; set; }
        public object AuthorFlairText { get; set; }
        public List<object> TreatmentTags { get; set; }
        public bool Visited { get; set; }
        public object RemovedBy { get; set; }
        public object NumReports { get; set; }
        public object Distinguished { get; set; }
        public string SubredditId { get; set; }
        public object ModReasonBy { get; set; }
        public object RemovalReason { get; set; }
        public string LinkFlairBackgroundColor { get; set; }
        public string Id { get; set; }
        public bool IsRobotIndexable { get; set; }
        public object ReportReasons { get; set; }
        public string Author { get; set; }
        public object DiscussionType { get; set; }
        public int NumComments { get; set; }
        public bool SendReplies { get; set; }
        public string WhitelistStatus { get; set; }
        public bool ContestMode { get; set; }
        public List<object> ModReports { get; set; }
        public bool AuthorPatreonFlair { get; set; }
        public object AuthorFlairTextColor { get; set; }
        public string Permalink { get; set; }
        public string ParentWhitelistStatus { get; set; }
        public bool Stickied { get; set; }
        public string Url { get; set; }
        public int SubredditSubscribers { get; set; }
        public double CreatedUtc { get; set; }
        public int NumCrossposts { get; set; }
        public object Media { get; set; }
        public bool IsVideo { get; set; }
    }

    public class P
    {
        public int Y { get; set; }
        public int X { get; set; }
        public string U { get; set; }
    }

    public class S
    {
        public int Y { get; set; }
        public int X { get; set; }
        public string U { get; set; }
    }

    public class F9vmp3oyfup61
    {
        public string Status { get; set; }
        public string E { get; set; }
        public string M { get; set; }
        public List<P> P { get; set; }
        public S S { get; set; }
        public string Id { get; set; }
    }

    public class Jfbio2oyfup61
    {
        public string Status { get; set; }
        public string E { get; set; }
        public string M { get; set; }
        public List<P> P { get; set; }
        public S S { get; set; }
        public string Id { get; set; }
    }

    public class _21qzcg5xctp61
    {
        public string Status { get; set; }
        public string E { get; set; }
        public string M { get; set; }
        public List<P> P { get; set; }
        public S S { get; set; }
        public string Id { get; set; }
    }

    public class S5ilfkqvctp61
    {
        public string Status { get; set; }
        public string E { get; set; }
        public string M { get; set; }
        public List<P> P { get; set; }
        public S S { get; set; }
        public string Id { get; set; }
    }

    public class Kazh4m6yctp61
    {
        public string Status { get; set; }
        public string E { get; set; }
        public string M { get; set; }
        public List<P> P { get; set; }
        public S S { get; set; }
        public string Id { get; set; }
    }

    public class _3qwcm6e09tp61
    {
        public string Status { get; set; }
        public string E { get; set; }
        public string M { get; set; }
        public List<P> P { get; set; }
        public S S { get; set; }
        public string Id { get; set; }
    }

    public class Na1abc809tp61
    {
        public string Status { get; set; }
        public string E { get; set; }
        public string M { get; set; }
        public List<P> P { get; set; }
        public S S { get; set; }
        public string Id { get; set; }
    }

    public class Eixoht8f3tp61
    {
        public string Status { get; set; }
        public string E { get; set; }
        public string M { get; set; }
        public List<P> P { get; set; }
        public S S { get; set; }
        public string Id { get; set; }
    }

    public class G7k4vu8f3tp61
    {
        public string Status { get; set; }
        public string E { get; set; }
        public string M { get; set; }
        public List<P> P { get; set; }
        public S S { get; set; }
        public string Id { get; set; }
    }

    public class Nobjy22ivsp61
    {
        public string Status { get; set; }
        public string E { get; set; }
        public string M { get; set; }
        public List<P> P { get; set; }
        public S S { get; set; }
        public string Id { get; set; }
    }

    public class _8bbve4civsp61
    {
        public string Status { get; set; }
        public string E { get; set; }
        public string M { get; set; }
        public List<P> P { get; set; }
        public S S { get; set; }
        public string Id { get; set; }
    }

    public class O2v83xx7fsp61
    {
        public string Status { get; set; }
        public string E { get; set; }
        public string M { get; set; }
        public List<P> P { get; set; }
        public S S { get; set; }
        public string Id { get; set; }
    }

    public class Ifwbn1k8fsp61
    {
        public string Status { get; set; }
        public string E { get; set; }
        public string M { get; set; }
        public List<P> P { get; set; }
        public S S { get; set; }
        public string Id { get; set; }
    }

    public class _20w96ji7fsp61
    {
        public string Status { get; set; }
        public string E { get; set; }
        public string M { get; set; }
        public List<P> P { get; set; }
        public S S { get; set; }
        public string Id { get; set; }
    }

    public class MediaMetadata
    {
        public F9vmp3oyfup61 F9vmp3oyfup61 { get; set; }
        public Jfbio2oyfup61 Jfbio2oyfup61 { get; set; }
        public _21qzcg5xctp61 _21qzcg5xctp61 { get; set; }
        public S5ilfkqvctp61 S5ilfkqvctp61 { get; set; }
        public Kazh4m6yctp61 Kazh4m6yctp61 { get; set; }
        public _3qwcm6e09tp61 _3qwcm6e09tp61 { get; set; }
        public Na1abc809tp61 Na1abc809tp61 { get; set; }
        public Eixoht8f3tp61 Eixoht8f3tp61 { get; set; }
        public G7k4vu8f3tp61 G7k4vu8f3tp61 { get; set; }
        public Nobjy22ivsp61 Nobjy22ivsp61 { get; set; }
        public _8bbve4civsp61 _8bbve4civsp61 { get; set; }
        public O2v83xx7fsp61 O2v83xx7fsp61 { get; set; }
        public Ifwbn1k8fsp61 Ifwbn1k8fsp61 { get; set; }
        public _20w96ji7fsp61 _20w96ji7fsp61 { get; set; }
    }

    public class Item
    {
        public string Caption { get; set; }
        public string MediaId { get; set; }
        public int Id { get; set; }
    }

    public class GalleryData
    {
        public List<Item> Items { get; set; }
    }

    public class Data
    {
        public object ApprovedAtUtc { get; set; }
        public string Subreddit { get; set; }
        public string Selftext { get; set; }
        public string AuthorFullname { get; set; }
        public bool Saved { get; set; }
        public object ModReasonTitle { get; set; }
        public int Gilded { get; set; }
        public bool Clicked { get; set; }
        public string Title { get; set; }
        public List<object> LinkFlairRichtext { get; set; }
        public string SubredditNamePrefixed { get; set; }
        public bool Hidden { get; set; }
        public int Pwls { get; set; }
        public string LinkFlairCssClass { get; set; }
        public int Downs { get; set; }
        public int? ThumbnailHeight { get; set; }
        public object TopAwardedType { get; set; }
        public bool HideScore { get; set; }
        public string Name { get; set; }
        public bool Quarantine { get; set; }
        public string LinkFlairTextColor { get; set; }
        public double UpvoteRatio { get; set; }
        public object AuthorFlairBackgroundColor { get; set; }
        public string SubredditType { get; set; }
        public int Ups { get; set; }
        public int TotalAwardsReceived { get; set; }
        public MediaEmbed MediaEmbed { get; set; }
        public int? ThumbnailWidth { get; set; }
        public object AuthorFlairTemplateId { get; set; }
        public bool IsOriginalContent { get; set; }
        public List<object> UserReports { get; set; }
        public SecureMedia SecureMedia { get; set; }
        public bool IsRedditMediaDomain { get; set; }
        public bool IsMeta { get; set; }
        public object Category { get; set; }
        public SecureMediaEmbed SecureMediaEmbed { get; set; }
        public string LinkFlairText { get; set; }
        public bool CanModPost { get; set; }
        public int Score { get; set; }
        public object ApprovedBy { get; set; }
        public bool AuthorPremium { get; set; }
        public string Thumbnail { get; set; }
        public object Edited { get; set; }
        public object AuthorFlairCssClass { get; set; }
        public List<object> AuthorFlairRichtext { get; set; }
        public Gildings Gildings { get; set; }
        public object ContentCategories { get; set; }
        public bool IsSelf { get; set; }
        public object ModNote { get; set; }
        public double Created { get; set; }
        public string LinkFlairType { get; set; }
        public int Wls { get; set; }
        public object RemovedByCategory { get; set; }
        public object BannedBy { get; set; }
        public string AuthorFlairType { get; set; }
        public string Domain { get; set; }
        public bool AllowLiveComments { get; set; }
        public string SelftextHtml { get; set; }
        public object Likes { get; set; }
        public object SuggestedSort { get; set; }
        public object BannedAtUtc { get; set; }
        public object ViewCount { get; set; }
        public bool Archived { get; set; }
        public bool NoFollow { get; set; }
        public bool IsCrosspostable { get; set; }
        public bool Pinned { get; set; }
        public bool Over18 { get; set; }
        public List<AllAwarding> AllAwardings { get; set; }
        public List<object> Awarders { get; set; }
        public bool MediaOnly { get; set; }
        public string LinkFlairTemplateId { get; set; }
        public bool CanGild { get; set; }
        public bool Spoiler { get; set; }
        public bool Locked { get; set; }
        public object AuthorFlairText { get; set; }
        public List<object> TreatmentTags { get; set; }
        public bool Visited { get; set; }
        public object RemovedBy { get; set; }
        public object NumReports { get; set; }
        public object Distinguished { get; set; }
        public string SubredditId { get; set; }
        public object ModReasonBy { get; set; }
        public object RemovalReason { get; set; }
        public string LinkFlairBackgroundColor { get; set; }
        public string Id { get; set; }
        public bool IsRobotIndexable { get; set; }
        public object ReportReasons { get; set; }
        public string Author { get; set; }
        public object DiscussionType { get; set; }
        public int NumComments { get; set; }
        public bool SendReplies { get; set; }
        public string WhitelistStatus { get; set; }
        public bool ContestMode { get; set; }
        public List<object> ModReports { get; set; }
        public bool AuthorPatreonFlair { get; set; }
        public object AuthorFlairTextColor { get; set; }
        public string Permalink { get; set; }
        public string ParentWhitelistStatus { get; set; }
        public bool Stickied { get; set; }
        public string Url { get; set; }
        public int SubredditSubscribers { get; set; }
        public double CreatedUtc { get; set; }
        public int NumCrossposts { get; set; }
        public Media Media { get; set; }
        public bool IsVideo { get; set; }
        public string PostHint { get; set; }
        public string UrlOverriddenByDest { get; set; }
        public Preview Preview { get; set; }
        public List<CrosspostParentList> CrosspostParentList { get; set; }
        public string CrosspostParent { get; set; }
        public bool? IsGallery { get; set; }
        public MediaMetadata MediaMetadata { get; set; }
        public GalleryData GalleryData { get; set; }
        public string Modhash { get; set; }
        public int Dist { get; set; }
        public List<Child> Children { get; set; }
        public string After { get; set; }
        public object Before { get; set; }
    }

    public class Child
    {
        public string Kind { get; set; }
        public Data Data { get; set; }
    }

    public class Root
    {
        public string Kind { get; set; }
        public Data Data { get; set; }
    }

}
