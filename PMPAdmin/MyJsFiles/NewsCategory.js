$("#newCategoryFormBtn").click(function () {

    var postData = $("#newCategoryForm").serialize();
    var postUrl = $("#postUrl").val();
    //var details = {};
    //details.Name = $("#categoryNameTextBox").val();
    //var postDat = JSON.stringify(details);

    // client side validation to see if all form fields is valid..
    if (!$("#newCategoryForm").valid()) {
        return false;
    }

    $("#spinnerModal").modal('show');

    $.ajax({
        url: postUrl,
        type: "post",
        data: postData,
        //contentType: "application/json;charset=utf-8",
        success: function (response) {
            if (response.status === "Successful") {
                $("#categoryNameTextBox").val("");
                location.reload(true);
                //var html = "";
                //$.each(response.data,
                //    function (index, row) {
                //        html = html + `<tr> <td>${index + 1}</td> <td>${row.Name}</td> <td>${row.AddedBy}</td> <td>${row.TimeCreated}</td> <td> <a href="#" type="button" class="btn btn-primary" id="editNewsCategoryBtn" onclick="Edit('@item.Id')">Edit</a> <a href= ${deleteUrl} type="button" class="btn btn-danger" id="deleteNewsCategoryBtn" onclick="Edit('@item.Id')">Delete <i class="fas fa-trash-alt"></i></a>`;
                //    });
                //$("#newsCategoryTableBody").append(html);
            }
        },
        error: function (error) {
            $("#spinnerModal").modal('hide');
            console.log(error);
        }
    });
});

// function to retrieve the category to be deleted by its Id and display the modal
var confirmDeleteCategory = function (categoryId) {

    //$("#deleteNewsCategoryBtn").html('<div><span class="spinner-border text-light" role="status"></span><span>Loading...</span></div>');
    var deleteUrl = `${$("#deleteUrl").val()}/${categoryId}`;
    console.log(deleteUrl);
    $.ajax({
        url: deleteUrl,
        type: "get",
        async: true,
        success: function (response) {
            if (response.status === "Successful") {
                //$("#deleteNewsCategoryBtn").html('Delete <i class="fas fa-trash-alt"></i>');
                $("#catNameModal").html(`<b>${response.data.Name}</b>`);
                $("#catTimeCreatedModal").html(`<b>${response.data.TimeCreated}</b>`);
                $("#catAddedByModal").html(`<b>${response.data.AddedBy}</b>`);

                //show the modal here....
                $("#deleteNewsCategoryModal").modal("show");

                $("#newsCategoryIdInput").val(response.data.categoryId);

            }
        }
    });
}

var deleteCategory = function () {

    $("#deleteCategoryBtn")
        .html('<div><span class="spinner-border text-danger" role="status">'+
            '</span> <span class="">Deleting...</span></div>');
    var deleteUrl = `${$("#deleteUrl").val()}/${$("#newsCategoryIdInput").val()}`;
    var postData = $("#newsCategoryModalForm").serialize();

    $.ajax({
        url: deleteUrl,
        type: "post",
        async: true,
        data: postData,
        success: function (response) {
            if (response.status === "Successful") {
                $("#deleteNewsCategoryModal").modal("hide");
                location.reload();
            }

        },
        error: function (error) {
            $("#deleteCategoryBtn").html("Delete Category");
            console.log(error);
        }
    });
}