var app = angular.module('myAuthor', []);
app.controller('myAuthorCtrl', function ($scope, $http) {
  
    $scope.GetAllAuthorsCtrl = function () {
        $http.get("/Api/GetAllAuthors")
            .then(function (response) {
                $scope.authors = response.data;
             });
    }

    $scope.AddAuthorCtrl = function (newAuthor) {
        $http.post("/Api/AddAuthor", newAuthor)
            .then(function (response) {
                $scope.AddAuthor = false;
                $scope.Authors = true;
                $scope.GetAllAuthorsCtrl();
             });
    }

    $scope.EditAuthorCtrl = function (editedAuthor) {
        $http.put("/Api/EditAuthor", editedAuthor)
            .then(function (response) {
                $scope.EditAuthor = false;
                $scope.Authors = true;
                $scope.GetAllAuthorsCtrl();
            });
    }

    $scope.DeleteAuthorCtrl = function (id) {
        $http.delete("/Api/DeleteAuthor/"+ id)
            .then(function (response) {
                $scope.GetAllAuthorsCtrl();
            });
    }

    $scope.showAddAuthor = function () {
        $scope.Authors = false;
        $scope.AddAuthor = true;
    }

    $scope.showEditAuthor = function (author) {
        $scope.Authors = false;
        $scope.EditAuthor = true;
        $scope.editedAuthor = author;
    }

    $scope.SortAuthorByLastName = function () {
        if ($scope.sortAuthor != '+LastName') {
            $scope.sortAuthor = '+LastName';
        }
        else {
            $scope.sortAuthor = '-LastName';
        }
    }

    $scope.SortAuthorByAge = function () {
        if ($scope.sortAuthor != '+Age') {
            $scope.sortAuthor = '+Age';
        }
        else {
            $scope.sortAuthor = '-Age';
        }
    }

    $scope.GetAllAuthorsCtrl();
});