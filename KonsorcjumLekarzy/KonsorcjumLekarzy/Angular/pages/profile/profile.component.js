(function() {
        "use strict";

        const module = angular.module("BlurAdmin.pages.profile");

        controller.$inject = ["$http"];

        function controller($http) {
            var vm = this;

            vm.updateUserInfo = function () {

                if (vm.currentUserRole !== "Admin") {
                    $http({
                            url: "/home/UpdateUserData",
                            method: "POST",
                            data: {
                                'id': vm.initData.User[0].UserDto.id,
                                'userName': vm.initData.User[0].UserDto.UserName,
                                'firstName': vm.initData.User[0].UserDto.FirstName,
                                'lastName': vm.initData.User[0].UserDto.LastName,
                                'birthDay': vm.initData.User[0].UserDto.BirthDay,
                                'phoneNumber': vm.initData.User[0].UserDto.PhoneNumber,
                                'email': vm.initData.User[0].UserDto.Email,
                                'roleName': vm.initData.User[0].UserDto.RoleName,
                                'password': vm.password
                            }
                        })
                        .then(function(response) {
                                vm.visitSaveStatus = "success";
                            },
                            function(response) {
                                vm.visitSaveStatus = "fail";
                                alert("Faild during booking visit. Please try again");
                            });
                } else {
                    $http({
                        url: "/home/UpdateUserData",
                        method: "POST",
                        data: {
                            'id': vm.initData.User.id,
                            'userName': vm.initData.User.UserName,
                            'firstName': "",
                            'lastName': "",
                            'birthDay': "",
                            'phoneNumber': vm.initData.User.PhoneNumber,
                            'email': vm.initData.User.Email,
                            'roleName': vm.initData.User.RoleName,
                            'password': vm.password
                        }
                    })
                    .then(function (response) {
                        vm.visitSaveStatus = "success";
                    },
                        function (response) {
                            vm.visitSaveStatus = "fail";
                            alert("Faild during booking visit. Please try again");
                        });
                }
                
            };

            var parseUserInfo = function() {
                const currentUser = global_InitData.User[0].id;
                vm.currentUserRole = global_InitData.User[0].RoleName;

                switch (vm.currentUserRole) {
                case "Doctor":
                    vm.initData.User = global_InitData.Doctors.filter(function(item, index, arr) {
                        if (item.UserDto.id === currentUser) {
                            return item.UserDto;
                        };
                    });
                    break;
                case "Patient":
                    vm.initData.User = global_InitData.Patients.filter(function(item, index, arr) {
                        if (item.UserDto.id === currentUser) {
                            return item.UserDto;
                        };
                    });
                    break;
                case "Admin":
                    vm.initData.User = {};
                    vm.initData.User = global_InitData.User[0];
                    break;
                default:
                    break;
                }
            };

            vm.$onInit = function () {
                vm.currentUserRole = "";
                vm.initData = {};
                vm.password = "";
                vm.passwordConfirm = "";
                parseUserInfo();
            };
        };

        module.component("profile",
        {
            templateUrl: "Angular/pages/profile/profile.html",
            controllerAs: "vm",
            controller: controller
        });
    })
    ();