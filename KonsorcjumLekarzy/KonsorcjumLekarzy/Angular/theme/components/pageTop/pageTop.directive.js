/**
 * @author v.lugovksy
 * created on 16.12.2015
 */
(function() {
    "use strict";

    var module = angular.module("BlurAdmin.theme.components");
    
    module.directive("pageTop", function() {
        
        var controller = function () {
            var vm = this;

            function init() {
                vm.user = global_InitData.User[0].UserName;
            }

            init();
        };

        return {
            restrict: "E",
            controller: controller,
            controllerAs: 'vm',
            templateUrl: "Angular/theme/components/pageTop/pageTop.html"
        };
    });
})();