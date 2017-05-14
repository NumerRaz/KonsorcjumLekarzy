(function () {
    'use strict';

    angular.module('BlurAdmin')
      .service('dataServices', dataServices);

    dataServices.$inject = ["$http"];

    /** @ngInject */
    function dataServices($http) {
        var initalData = {};

        var getInitDate = function() {
            
        }

        return {
            initData: getInitDate()
        }
    }

})();