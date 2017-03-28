﻿(function () {
    "use strict";

    angular
        .module("productManagement")
        .controller("ProductListCtrl", 
                    ["productResource", productListCtrl]);

    function productListCtrl(productResource) {
        var vm = this;

        vm.searchCriteria = "GDN";

        productResource.query({$skip:1, $top:3}, function (data) {
            vm.products = data;
        });

    }
}());