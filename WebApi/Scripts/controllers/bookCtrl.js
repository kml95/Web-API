var app = angular.module('myBook', []);
app.controller('myBookCtrl', function ($scope, $http) {

    $scope.GetAllBooksCtrl = function () {
        $http.get("/Api/GetAllBooks")
             .then(function (response) {
                $scope.books = response.data;
             });
    }

    $scope.AddBookCtrl = function (newBook) {
        $http.post("/Api/AddBook", newBook)
            .then(function (response) {

                $scope.AddBook = false;
                $scope.Books = true;
                $scope.GetAllBooksCtrl();
             });
    }

    $scope.EditBookCtrl = function (editedBook) {
        $http.put("/Api/EditBook", editedBook)
            .then(function (response) {
                $scope.EditBook = false;
                $scope.Books = true;
                $scope.GetAllBooksCtrl();
            });
    }

    $scope.DeleteBookCtrl = function (id) {
        $http.delete("/Api/DeleteBook/" + id)
            .then(function (response) {
                $scope.GetAllBooksCtrl();
            });
    }

    $scope.showAddBook = function () {
        $scope.Books = false;
        $scope.AddBook = true;
    }

    $scope.showEditBook = function (book) {
        $scope.Books = false;
        $scope.EditBook = true;
        $scope.editedBook = book;
    }

    $scope.SortBookByTitle = function () {
        if ($scope.sortBook != '+Title') {
            $scope.sortBook = '+Title';
        }
        else {
            $scope.sortBook = '-Title';
        }
    }

    $scope.SortBookByYear = function () {
        if ($scope.sortBook != '+Year') {
            $scope.sortBook = '+Year';
        }
        else {
            $scope.sortBook = '-Year';
        }
    }

    $scope.GetAllBooksCtrl();
});