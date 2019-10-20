"use strict";

$(document).ready(function () {
    
    // Start Home Page 
    // Mobile Navbar 
    $(document).on("click", ".menu-icon", function () {
        $(".nav-mobile").slideToggle();
    });

    // Scroll to Top
    $(document).on("click", ".goTop", function (e) {

        e.preventDefault();

        $("html").animate({ scrollTop: 0 }, '500');

    });

    // Scroll to Bottom
    $(document).on("click", ".scroll-bottom", function (e) {
        e.preventDefault();

        var winHeight = $('header').outerHeight() + $("#news-main").outerHeight();

        $("html").animate({ scrollTop: winHeight }, '500');
    });

    // End Home Page 

    // Start News Details Slider


    let totalWidth = $(".news-details-img .slider-lent li").length * 100;


    $(".news-details-img .slider-lent").css("width", totalWidth + "%");

    let index = 0;
    
    $(document).on("click", ".news-details-img .arrow-right", function () {


        index++;

        $(".news-details-img .slider-lent").css(
            {
                left: -index * 100 + "%"
            })

        if (index === $(".news-details-img .slider-lent li").length) {
            index = 0;
            $(".news-details-img .slider-lent").css(
                {
                    left: -index * 100 + "%"
                })
        }
    });
    $(document).on("click", ".news-details-img .arrow-left", function () {



        index--;

        $(".news-details-img .slider-lent").css(
            {
                left: -index * 100 + "%"
            })

        if (index < 0) {
            index = $(".news-details-img .slider-lent li").length - 1;
            $(".news-details-img .slider-lent").css(
                {
                    left: -index * 100 + "%"
                })
        }
    });

    // End News Details Slider


    // Start Product Slider Images

    $(document).on("click", ".product-slider-images li img", function(){

        let product_image = $(this).attr("src");
        $(".product-slider-images li.hover-slider-active").removeClass("hover-slider-active");
        $(this).parent().addClass("hover-slider-active");

        $(".one-image img").attr("src", product_image);
    })


    //Filter Shop Brands with Tags
    $(function () {
        $("#category").change(function () {
            var tagsId = $(this).val();
            var categoryId = +$("#categoryId").val();
            shopCount = 8;

            if (tagsId != 0) {
                $.ajax({
                    url: "/Ajax/LoadBrandsbyTagsId?TagsId=" + tagsId,
                    type: "POST",
                    success: function (res) {
                        if (res != 0) {
                            $("#stores .container .shopRow").html(res);
                        }
                        else {
                            $("#stores .container .shopRow").html("<div class='col-12'><p class='notFound'>Axtardığınız kateqoriyaya uyğun Brand tapılmadı</p></div>");
                        }
                        $(".btn-shop").css("display", "none");
                    }
                });
            }
            if (tagsId == 0) {
                $.ajax({
                    url: "/Ajax/LoadAllBrands?CategoryId=" + categoryId,
                    type: "POST",
                    success: function (res) {
                        if (res != 0) {
                            $("#stores .container .shopRow").html(res);
                        }
                        else {
                            $("#stores .container .shopRow").html("<div class='col-12'><p class='notFound'>Axtardığınız kateqoriyaya uyğun Brand tapılmadı</p></div>");
                        }
                        if ($(".store-content").length >= 8) {
                            $(".btn-shop").css("display", "block");
                        }
                        else {
                            $(".btn-shop").css("display", "none");
                        }
                    }
                });
            }
        });
    });

    //Filter Entertainment Brands with Tags
    $(function () {
        $(".entertainmentCategory").change(function () {
            var tagsId = $(this).val();
            var categoryId = +$("#entertainmentCategoryId").val();
            entertainmentCount = 8;

            if (tagsId != 0) {
                $.ajax({
                    url: "/Ajax/LoadBrandsbyTagsId?TagsId=" + tagsId,
                    type: "POST",
                    success: function (res) {
                        if (res != 0) {
                            $("#entertainment .container .entertainmentRow").html(res);
                        }
                        else {
                            $("#entertainment .container .entertainmentRow").html("<div class='col-12'><p class='notFound'>Axtardığınız kateqoriyaya uyğun Brand tapılmadı</p></div>");
                        }
                        $(".btn-entertainment").css("display", "none");
                    }
                });
            }
            if (tagsId == 0) {
                $.ajax({
                    url: "/Ajax/LoadAllBrands?CategoryId=" + categoryId,
                    type: "POST",
                    success: function (res) {
                        if (res != 0) {
                            $("#entertainment .container .entertainmentRow").html(res);
                        }
                        else {
                            $("#entertainment .container .entertainmentRow").html("<div class='col-12'><p class='notFound'>Axtardığınız kateqoriyaya uyğun Brand tapılmadı</p></div>");
                        }
                        if ($(".store-content").length >= 8) {
                            $(".btn-entertainment").css("display", "block");
                        }
                        else {
                            $(".btn-entertainment").css("display", "none");
                        }
                    }
                });
            }
        });
    });

    //Filter Restaurant Brands with Tags
    $(function () {
        $(".restaurantCategory").change(function () {
            var tagsId = $(this).val();
            var categoryId = +$("#restaurantCategoryId").val();
            restaurantCount = 8;

            if (tagsId != 0) {
                $.ajax({
                    url: "/Ajax/LoadBrandsbyTagsId?TagsId=" + tagsId,
                    type: "POST",
                    success: function (res) {
                        if (res != 0) {
                            $("#restaurants .container .restaurantRow").html(res);
                        }
                        else {
                            $("#restaurants .container .restaurantRow").html("<div class='col-12'><p class='notFound'>Axtardığınız kateqoriyaya uyğun Brand tapılmadı</p></div>");
                        }
                        $(".btn-restaurant").css("display", "none");
                    }
                });
            }
            if (tagsId == 0) {
                $.ajax({
                    url: "/Ajax/LoadAllBrands?CategoryId=" + categoryId,
                    type: "POST",
                    success: function (res) {
                        if (res != 0) {
                            $("#restaurants .container .restaurantRow").html(res);
                        }
                        else {
                            $("#restaurants .container .restaurantRow").html("<div class='col-12'><p class='notFound'>Axtardığınız kateqoriyaya uyğun Brand tapılmadı</p></div>");
                        }
                        if ($(".restaurant-content").length >= 8) {
                            $(".btn-restaurant").css("display", "block");
                        }
                        else {
                            $(".btn-restaurant").css("display", "none");
                        }
                    }
                });
            }
        });
    });

    //Shop Brands LOad More with Ajax
    var shopCount = 8;
    $(".btn-shop").click(function (e) {
        var totalCount = +$("#shopDetails").val();

        e.preventDefault();
        $.ajax({
            url: "/Ajax/LoadBrands?skip=" + shopCount,
            type: "GET",
            success: function (res) {
                $("#stores .shopRow").append(res);
                shopCount += 4;

                if (shopCount >= totalCount) {
                    $(".btn-shop").css("display", "none");
                }
            }
        });
    });

    //Shop Products Load More with Ajax
    var shopProductCount = 8;
    $(".btn-shop-details").click(function (e) {
        var brandId = $("#brandId").val();
        var userId = $("#userId").val();

        var totalCount = +$("#productDetails").val();
        
        e.preventDefault();
        $.ajax({
            url: "/Ajax/LoadProducts?skip=" + shopProductCount + "&brandId=" + brandId + "&userId=" + userId,
            type: "GET",
            success: function (res) {
                $("#products-shop .productRow").append(res);
                shopProductCount += 4;

                if (shopProductCount >= totalCount) {
                    $(".btn-shop-details").css("display", "none");
                }
            }
        });
    });

    //Restaurant Brands LOad More with Ajax
    var restaurantCount = 8;
    $(".btn-restaurant").click(function (e) {
        var totalCount = +$("#restaurantDetails").val();

        e.preventDefault();
        $.ajax({
            url: "/Ajax/LoadRestaurantBrands?skip=" + restaurantCount,
            type: "GET",
            success: function (res) {
                $("#restaurants .restaurantRow").append(res);
                restaurantCount += 4;

                if (restaurantCount >= totalCount) {
                    $(".btn-restaurant").css("display", "none");
                }
            }
        });
    });

    //Restaurant Products Load More with Ajax
    var restaurantProductCount = 8;
    $(".btn-entertainment-product").click(function (e) {
        var brandId = $("#entertainmentBrandId").val();
        var userId = $("#entertainmentUserId").val();

        var totalCount = +$("#entertainmentProductCount").val();

        e.preventDefault();
        $.ajax({
            url: "/Ajax/LoadEntertainmentProducts?skip=" + restaurantProductCount + "&brandId=" + brandId + "&userId=" + userId,
            type: "GET",
            success: function (res) {
                $("#products-cinema .productRow").append(res);
                restaurantProductCount += 4;

                if (restaurantProductCount >= totalCount) {
                    $(".btn-entertainment-product").css("display", "none");
                }
            }
        });
    });

    //Entertainment Brands LOad More with Ajax
    var entertainmentCount = 8;
    $(".btn-entertainment").click(function (e) {
        var totalCount = +$("#entertainmentCount").val();

        e.preventDefault();
        $.ajax({
            url: "/Ajax/LoadEntertainmentBrands?skip=" + entertainmentCount,
            type: "GET",
            success: function (res) {
                $("#entertainment .entertainmentRow").append(res);
                entertainmentCount += 4;

                if (entertainmentCount >= totalCount) {
                    $(".btn-entertainment").css("display", "none");
                }
            }
        });
    });

    //Entertainment Products Load More with Ajax
    var entertainmentProductCount = 8;
    $(".btn-product-restaurant").click(function (e) {
        var brandId = $("#restaurantBrandId").val();
        var userId = $("#restaurantUserId").val();

        var totalCount = +$("#restaurantProductsDetails").val();

        e.preventDefault();
        $.ajax({
            url: "/Ajax/LoadRestaurantProducts?skip=" + entertainmentProductCount + "&brandId=" + brandId + "&userId=" + userId,
            type: "GET",
            success: function (res) {
                $("#products-restaurant .productRow").append(res);
                entertainmentProductCount += 4;

                if (entertainmentProductCount >= totalCount) {
                    $(".btn-product-restaurant").css("display", "none");
                }
            }
        });
    });

    //News Load More with Ajax
    var newsCount = 16;
    $(".btn-news").click(function (e) {
        var totalCount = +$("#news-hidden-input").val();

        e.preventDefault();
        $.ajax({
            url: "/Ajax/LoadNews?skip=" + newsCount,
            type: "GET",
            success: function (res) {
                $("#news-wrapper .newsRow").append(res);
                newsCount += 8;

                if (newsCount >= totalCount) {
                    $(".btn-news").css("display", "none");
                }
            }
        });
    });

    //Upload Input with Icons
    $(document).on("click", ".uploadImage", function () {
        $("#uploadInput").click();
    });
    $(document).on("click", ".uploadImage", function () {
        $(".uploadInput").click();
    });
    $(document).on("click", ".uploadImageSecond", function () {
        $(".uploadInputSecond").click();
    });
    $(document).on("click", ".uploadImageThird", function () {
        $(".uploadInputThird").click();
    });
    $(document).on("click", ".uploadImageFour", function () {
        $(".uploadInputFour").click();
    });
    $(document).on("click", ".uploadImageFive", function () {
        $(".uploadInputFive").click();
    });

    //Admin panel Active Navbar
    $(document).on("click", ".has-sub-admin", function () {
        console.log("sdgdfg");
        $(".has-sub-admin.activeAdminNavbar").removeClass(".activeAdminNavbar");
        $(this).addClass("activeAdminNavbar");
    });

    //Tabs Admin Panel Products
    $(document).on("click", '.tabs li',function () {

            $('.tabs li.active').removeClass("active");
            $(this).addClass("active");

            TabContentChanger();
    });

    function TabContentChanger() {
        $('.tab_content.active').removeClass("active");

        const index = $('.tabs li.active').attr("data-index");
        const connectedTab = $(`.tab_content[data-index="${index}"]`);
        connectedTab.addClass("active");
    }

    $(document).on("click", ".film-head", function () {

    });

   
    // Pre Loader

    $(".loader-wrapper").css("opacity", 0)
                        .css("visibility", "hidden");


    AOS.init();
                        
});

