
//Handles the news type dropdown list...
$("#newsTypeDropDown").change(function () {
    var selectedType = $(this).children("option:selected").val();

    if (selectedType == "Text" || selectedType === "Video") {
        $("#newsTypeErrorDiv").html("");
        $("#newsCategoryDiv").css({ display: "block" });
        $("#newsTitleDiv").css({ display: "block" });
        $("#newsDetailsDiv").css({ display: "block" });
        $("#newsImageDiv").css({ display: "block" });
    } else {
        $("#newsTypeErrorDiv").html("Please select a news type from the list.");
        $("#newsCategoryDiv").css({ display: "none" });
        $("#newsTitleDiv").css({ display: "none" });
        $("#newsDetailsDiv").css({ display: "none" });
        $("#newsImageDiv").css({ display: "none" });
        return false;
    }
});


//Handles the image select button...
$("#newsImageFileBox").change(function () {

    var imageFile = this.files;

    if (imageFile && imageFile[0]) {
        $("#newsImageErrorDiv").html("");
        imageFileReader(imageFile[0]);
    } else {
        $("#newsImageErrorDiv").html("Please select a valid image file for this news.");
    }
})

//This function will read the uploaded image file...
var imageFileReader = function (file) {
    var fileReader = new FileReader;
    var image = new Image;

    fileReader.readAsDataURL(file);
    fileReader.onload = function (_readFile) {
        image.src = _readFile.target.result;
        image.onload = function () {

            var height = this.height;
            var width = this.width;
            var type = file.type;
            var size = ~~(file.size / 1024) + "KB";

            $("#newsImagePreviewImg").attr("src", _readFile.target.result);
            $("#newsImagePreviewDiv").show();
        }

    }
}

var ClearImage = function() {
    $("#newsImageFileBox").val("");
    $("#newsImagePreviewDiv").hide();
}


// This function will handle the submit form function....
$("#newNewsFormBtn").click(function (e) {
    debugger;

    //Get the value of the selected news title...
    var selectedType = $("#newsTypeDropDown option:selected").val();

    //Get the value of the selected news category...
    var selectedCategory = $("#newsCategoryIdDropDown option:selected").val();

    //Get value of news title....
    var newsTitle = $("#newsTitleTextBox").val();

    //Get value of the news details....
    var newsDetails = $("#newsDetailsTextBox").val();

    //Get value of the news image....
    var newsImage = $("#newsImageFileBox").val();

    // client side validation to see if all form fields is valid..
    if (!$("#newNewsForm").valid()) {
        return false;
    }

    var postData = $("#newNewsForm").serialize();
    var postUrl = $("#postUrl").val();
    //var details = {};
    //details.Name = $("#categoryNameTextBox").val();
    //var postDat = JSON.stringify(details);


    //$("#spinnerModal").modal('show');

    //$.ajax({
    //    url: postUrl,
    //    type: "post",
    //    data: postData,
    //    //contentType: "application/json;charset=utf-8",
    //    success: function (response) {
    //        if (response.status === "Successful") {
    //            $("#categoryNameTextBox").val("");
    //            location.reload(true);
    //            //var html = "";
    //            //$.each(response.data,
    //            //    function (index, row) {
    //            //        html = html + `<tr> <td>${index + 1}</td> <td>${row.Name}</td> <td>${row.AddedBy}</td> <td>${row.TimeCreated}</td> <td> <a href="#" type="button" class="btn btn-primary" id="editNewsCategoryBtn" onclick="Edit('@item.Id')">Edit</a> <a href= ${deleteUrl} type="button" class="btn btn-danger" id="deleteNewsCategoryBtn" onclick="Edit('@item.Id')">Delete <i class="fas fa-trash-alt"></i></a>`;
    //            //    });
    //            //$("#newsCategoryTableBody").append(html);
    //        }
    //    },
    //    error: function (error) {
    //        $("#spinnerModal").modal('hide');
    //        console.log(error);
    //    }
    //});
});

//// function to retrieve the category to be deleted by its Id and display the modal
//var confirmDisableNews = function (newsId) {

//    //$("#deleteNewsCategoryBtn").html('<div><span class="spinner-border text-light" role="status"></span><span>Loading...</span></div>');
//    var deleteUrl = `${$("#deleteUrl").val()}/${newsId}`;

//    $.ajax({
//        url: deleteUrl,
//        type: "get",
//        async: true,
//        success: function (response) {
//            if (response.status === "Successful") {
//                //$("#deleteNewsCategoryBtn").html('Delete <i class="fas fa-trash-alt"></i>');
//                $("#catNameModal").html(`<b>${response.data.Name}</b>`);
//                $("#catTimeCreatedModal").html(`<b>${response.data.TimeCreated}</b>`);
//                $("#catAddedByModal").html(`<b>${response.data.AddedBy}</b>`);

//                //show the modal here....
//                $("#deleteNewsCategoryModal").modal("show");

//                $("#newsCategoryIdInput").val(response.data.categoryId);

//            }
//        }
//    });
//}

//var deleteCategory = function () {

//    $("#deleteCategoryBtn")
//        .html('<div><span class="spinner-border text-danger" role="status">' +
//            '</span> <span class="">Deleting...</span></div>');
//    var deleteUrl = `${$("#deleteUrl").val()}/${$("#newsCategoryIdInput").val()}`;
//    var postData = $("#newsCategoryModalForm").serialize();

//    $.ajax({
//        url: deleteUrl,
//        type: "post",
//        async: true,
//        data: postData,
//        success: function (response) {
//            if (response.status === "Successful") {
//                $("#deleteNewsCategoryModal").modal("hide");
//                location.reload();
//            }

//        },
//        error: function (error) {
//            $("#deleteCategoryBtn").html("Delete Category");
//            console.log(error);
//        }
//    });
//}