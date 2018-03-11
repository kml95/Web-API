var app = angular.module('MY', []);
app.controller('myBookCtrl', function ($scope, $http) {

    $scope.GetAllBooks= function () {
        $http.get("/Api/GetAllBooks")
            .then(function (response) {
                $scope.books = response.data;
            });
    }

    $scope.GetAllBooks();
});