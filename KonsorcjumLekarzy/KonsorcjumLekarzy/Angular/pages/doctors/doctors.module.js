(function() {
    "use strict";

    var module = angular.module("BlurAdmin.pages.doctors", ["ui.select", "smart-table"]);

    module.config(routeConfig); 

    function routeConfig($stateProvider) {
        $stateProvider
            .state("doctors",
            {
                url: "/doctors", 
                template: "<doctors></doctors>", 
                title: "Doctors", 
                sidebarMeta: {
                    icon: 'ion-stats-bars', 
                    order: 1
                }
            });
    }

})(); 