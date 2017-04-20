(function() {
    "use strict";

    var module = angular.module("BlurAdmin.pages.bookingvisit", []);

    module.config(routeConfig);

    function routeConfig($stateProvider) {
        $stateProvider
            .state("bookingvisit",
            {
                url: "/bookingvisit",
                template: "<bookingvisit></bookingvisit>",
                title: "Visit",
                sidebarMeta: {
                    icon: 'ion-stats-bars',
                    order: 2
                }
            });
    }

})(); 