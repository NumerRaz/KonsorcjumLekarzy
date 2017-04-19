(function() {
    "use strict";

    angular.module('BlurAdmin.theme.components')
        .component("userAuthorize",
        {
            template: "<p ng-click=\"vm.signOut()\">Sign out</p>",
            controllerAs: "vm",
            bindings: {
                signOff: "@"
            },
            controller: ["$http", signAuthorizeCntr]
        });

    function signAuthorizeCntr($http) {
        var vm = this;

        vm.signOut = function () {
            alert("test");
            $http.post("/logoff");
        };

        vm.$onInit = function() {
        };
    };

})();