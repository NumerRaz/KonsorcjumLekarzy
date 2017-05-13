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

    var parseData = function() {
        for (var doctor = 0; doctor < global_InitData.length; doctor++) {
            vm.standardSelectItems.push({
                label: global_InitData[doctor].FirstName + " " + global_InitData[doctor].LastName,
                value: global_InitData[doctor].DoctorId
            });

            console.log(vm.standardSelectItems);
        }
    };

    
    vm.selectDoctors = function($item) {
        vm.doctors = $item.label;
    }

    vm.$onInit = function () {
        vm.disabled = undefined;
        vm.standardItem = {};
        vm.standardSelectItems = [];
        parseData();
        console.log("Select" + vm.doctors);
    };
   } 

  model.component("selectPickerPanel", {
      templateUrl: 'Angular/pages/doctors/selectPanel/select.html',
      controllerAs: "vm",
      bindings: {
          doctors: '<'
      },
      controller: controller
  });

})();


