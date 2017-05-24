(function () {
    "use strict";

    var module = angular.module("BlurAdmin.pages.profile", []);

    module.config(routeConfig);

    function routeConfig($stateProvider) {
        $stateProvider
            .state("profile",
            {
                url: "/profile",
                template: "<profile></profile>",
                title: "Profile",
                sidebarMeta: {
                    icon: 'ion-stats-bars',
                    order: 3
                }
            });
    }

})();