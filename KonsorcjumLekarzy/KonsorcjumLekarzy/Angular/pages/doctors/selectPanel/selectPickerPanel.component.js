/**
 * @author p.maslava
 * created on 28.11.2016
 */
(function () {
  'use strict';

   var model = angular.module('BlurAdmin.pages.doctors');

  /** @ngInject */
   function controller() {

    var vm = this;
    vm.disabled = undefined;

    vm.standardItem = {};
    vm.standardSelectItems = [
      {label: 'Option 1', value: 1},
      {label: 'Option 2', value: 2},
      {label: 'Option 3', value: 3},
      {label: 'Option 4', value: 4}
    ];
    
    vm.selectDoctors = function($item) {
        vm.doctors = $item.label;
    }
  }

  model.component("selectPickerPanel", {
      templateUrl: 'Angular/pages/doctors/selectPanel/select.html',
      controllerAs: "vm",
      bindings: {
          doctors: '='
      },
      controller: controller
  });

})();


