/// <reference path="../angular.min.js" />

var myapp = angular.module("TYGYApp", ['angularUtils.directives.dirPagination'])
myapp.controller("GetGuitars-Controller", function ($scope, $http) {
    $http({
        method: 'get',
        url: '/Home/GetGuitars'
    }).then(function Success(d) {
        $scope.guitars = d.data.guitars;
    }, function Error(error) { })
})

myapp.controller("GetGuitarsPage", function ($scope, $http,$rootScope) {
    $scope.maxSize = 3;
    $scope.pageIndex = 1;
    $scope.pageSize = 2;
    $scope.totalCount = 0;
    $scope.searchName = "";
    $scope.getGuitarsForPage = function (index) {
        $http.get('/Guitar/Get_Guitars_For_Page', {
            params: {
                pageIndex: index,
                pageSize: $scope.pageSize,
                guitarName: $scope.searchName
            }
        }).then(
            function (res) {
                $rootScope.Listguitars = res.data.guitars.Guitars
                $rootScope.totalCount = res.data.guitars.totalCount
                console.log($rootScope.Listguitars)
                console.log($rootScope.totalCount)
            },
            function (err) {
                alert(err)
            }
        )
    }
    $scope.getGuitarsForPage($scope.pageIndex)
})

myapp.controller("GetGuitarDetails", function ($scope, $http) {
    $scope.guitar_id = localStorage.getItem("guitar_id")
    $scope.guitar_id = "GT-1GC"
    $http.get('/Guitar/GetGuitarDetails', {
        params: {
            guitar_id: $scope.guitar_id
        }
    }).then(
        function (res) {
            $scope.guitar = res.data.guitar
            $scope.images = res.data.guitar.guitar_images
            $scope.image_base = ""
            $scope.image_small = []
            $scope.image_descript = []
            for (i in $scope.images) {
                if ($scope.images[i].brand == 1)
                    $scope.image_base = $scope.images[i].img_name
                else if ($scope.images[i].brand == 2)
                    $scope.image_small.push($scope.images[i])
                else if ($scope.images[i].brand == 3)
                    $scope.image_descript.push($scope.images[i])
            }
        },
        function (err) {
            alert(err)
        }
    )
})