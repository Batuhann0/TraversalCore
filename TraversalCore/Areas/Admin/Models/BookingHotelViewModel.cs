using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCore.Areas.Admin.Models
{
    public class BookingHotelViewModel
    {

        public Result[] result { get; set; }
        public Sort[] sort { get; set; }
        public string search_id { get; set; }
        public int extended_count { get; set; }
        public object[] recommended_filters { get; set; }
        public Sorting sorting { get; set; }
        public string has_low_availability { get; set; }
        public int unfiltered_count { get; set; }
        public B_Max_Los_Data b_max_los_data { get; set; }
        public int total_count_with_filters { get; set; }
        public Applied_Filters[] applied_filters { get; set; }
        public int ranking_version { get; set; }
        public Base_Filters[] base_filters { get; set; }
        public string search_metadata { get; set; }
        public string[] copyright { get; set; }
        public Room_Distribution[] room_distribution { get; set; }
        public int page_loading_threshold { get; set; }
        public int search_radius { get; set; }
        public int primary_count { get; set; }
        public int is_beach_ufi { get; set; }
        public int count { get; set; }
        public int unfiltered_primary_count { get; set; }

        public class Sorting
        {
            public string selected_identifier { get; set; }
            public Option[] options { get; set; }
        }

        public class Option
        {
            public string name { get; set; }
            public string loading_message { get; set; }
            public string identifier { get; set; }
        }

        public class B_Max_Los_Data
        {
            public int has_extended_los { get; set; }
            public int max_allowed_los { get; set; }
            public string experiment { get; set; }
            public int extended_los { get; set; }
            public int default_los { get; set; }
            public int is_fullon { get; set; }
        }

        public class Result
        {
            public object updated_checkout { get; set; }
            public string hotel_facilities { get; set; }
            public string hotel_name_trans { get; set; }
            public string district { get; set; }
            public Bwallet bwallet { get; set; }
            public string city_in_trans { get; set; }
            public Badge[] badges { get; set; }
            public int in_best_district { get; set; }
            public float latitude { get; set; }
            public int is_smart_deal { get; set; }
            public string hotel_name { get; set; }
            public string city_name_en { get; set; }
            public float review_score { get; set; }
            public string address { get; set; }
            public int class_is_estimated { get; set; }
            public string review_score_word { get; set; }
            public string city_trans { get; set; }
            public object is_geo_rate { get; set; }
            public int native_ads_cpc { get; set; }
            public string country_trans { get; set; }
            public int main_photo_id { get; set; }
            public int is_mobile_deal { get; set; }
            public object selected_review_topic { get; set; }
            public int urgency_room_c { get; set; }
            public string currency_code { get; set; }
            public string native_ad_id { get; set; }
            public string native_ads_tracking { get; set; }
            public Checkout checkout { get; set; }
            public string cc1 { get; set; }
            public Checkin checkin { get; set; }
            public string url { get; set; }
            public int is_beach_front { get; set; }
            public object updated_checkin { get; set; }
            public string type { get; set; }
            public Price_Breakdown price_breakdown { get; set; }
            public string accommodation_type_name { get; set; }
            public int district_id { get; set; }
            public string main_photo_url { get; set; }
            public string default_language { get; set; }
            public int cant_book { get; set; }
            public float longitude { get; set; }
            public int preferred { get; set; }
            public string review_recommendation { get; set; }
            public int wishlist_count { get; set; }
            public int _class { get; set; }
            public int extended { get; set; }
            public string districts { get; set; }
            public int has_swimming_pool { get; set; }
            public int preferred_plus { get; set; }
            public int ufi { get; set; }
            public int price_is_final { get; set; }
            public int is_city_center { get; set; }
            public int genius_discount_percentage { get; set; }
            public string zip { get; set; }
            public int is_no_prepayment_block { get; set; }
            public string id { get; set; }
            public int is_free_cancellable { get; set; }
            public int children_not_allowed { get; set; }
            public float min_total_price { get; set; }
            public string[] block_ids { get; set; }
            public int accommodation_type { get; set; }
            public int hotel_include_breakfast { get; set; }
            public int soldout { get; set; }
            public string address_trans { get; set; }
            public string distance { get; set; }
            public string timezone { get; set; }
            public int review_nr { get; set; }
            public string city { get; set; }
            public int hotel_has_vb_boost { get; set; }
            public string distance_to_cc { get; set; }
            public Deals deals { get; set; }
            public float mobile_discount_percentage { get; set; }
            public string currencycode { get; set; }
            public string default_wishlist_name { get; set; }
            public int is_genius_deal { get; set; }
            public Matching_Units_Configuration matching_units_configuration { get; set; }
            public int hotel_id { get; set; }
            public int cc_required { get; set; }
            public string countrycode { get; set; }
            public int has_free_parking { get; set; }
            public External_Reviews external_reviews { get; set; }
            public Booking_Home booking_home { get; set; }
        }

        public class Bwallet
        {
            public int hotel_eligibility { get; set; }
        }

        public class Checkout
        {
            public string until { get; set; }
            public string from { get; set; }
        }

        public class Checkin
        {
            public string from { get; set; }
            public string until { get; set; }
        }

        public class Price_Breakdown
        {
            public int has_fine_print_charges { get; set; }
            public float all_inclusive_price { get; set; }
            public object gross_price { get; set; }
            public object sum_excluded_raw { get; set; }
            public int has_incalculable_charges { get; set; }
            public int has_tax_exceptions { get; set; }
            public string currency { get; set; }
        }

        public class Deals
        {
            public int deal_events_killswitch { get; set; }
            public Deal_Attributes deal_attributes { get; set; }
            public Deals_Available deals_available { get; set; }
            public Deal_Events[] deal_events { get; set; }
        }

        public class Deal_Attributes
        {
        }

        public class Deals_Available
        {
            public int has_preset { get; set; }
        }

        public class Deal_Events
        {
            public string name_translation_tag { get; set; }
            public string text_color { get; set; }
            public int disabled { get; set; }
            public string description_translation_tag { get; set; }
            public string icon_url { get; set; }
            public int code { get; set; }
            public string icon_name { get; set; }
            public string localized_name { get; set; }
            public int discount_percentage { get; set; }
            public string localized_description { get; set; }
            public object preset_id { get; set; }
            public string bg_color { get; set; }
        }

        public class Matching_Units_Configuration
        {
            public Matching_Units_Common_Config matching_units_common_config { get; set; }
        }

        public class Matching_Units_Common_Config
        {
            public int unit_type_id { get; set; }
            public string localized_area { get; set; }
        }

        public class External_Reviews
        {
            public int score { get; set; }
            public string score_word { get; set; }
            public int num_reviews { get; set; }
            public string should_display { get; set; }
        }

        public class Booking_Home
        {
            public int is_single_unit_property { get; set; }
            public int is_booking_home { get; set; }
            public string group { get; set; }
            public int quality_class { get; set; }
            public int segment { get; set; }
        }

        public class Badge
        {
            public string badge_variant { get; set; }
            public string text { get; set; }
            public string id { get; set; }
        }

        public class Sort
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Applied_Filters
        {
            public string name { get; set; }
            public string generic_id { get; set; }
        }

        public class Base_Filters
        {
            public string type { get; set; }
            public string irene_resp_id { get; set; }
            public string title { get; set; }
            public string iconfont { get; set; }
            public Category[] categories { get; set; }
            public string subtitle { get; set; }
            public string any_text { get; set; }
            public int is_group { get; set; }
            public Layout layout { get; set; }
            public string id { get; set; }
            public Experiment_Tracking_Data experiment_tracking_data { get; set; }
        }

        public class Layout
        {
            public int collapsed_count { get; set; }
            public int is_collapsable { get; set; }
            public int is_collapsed { get; set; }
        }

        public class Experiment_Tracking_Data
        {
            public Track_On_View[] track_on_view { get; set; }
        }

        public class Track_On_View
        {
            public int value { get; set; }
            public int type { get; set; }
            public string experiment_tag { get; set; }
        }

        public class Category
        {
            public int count { get; set; }
            public int style_for_count { get; set; }
            public string name { get; set; }
            public string id { get; set; }
            public int selected { get; set; }
            public int popular_rank { get; set; }
            public int popular { get; set; }
            public int from { get; set; }
            public int to { get; set; }
            public string display_format { get; set; }
        }

        public class Room_Distribution
        {
            public string adults { get; set; }
            public int[] children { get; set; }
        }


    }
}
