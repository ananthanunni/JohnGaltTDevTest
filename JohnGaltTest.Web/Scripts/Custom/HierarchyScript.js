$(function () {
    var root = $("input[name=__rootPath]").val();

    var getChildren = function (element, parentId) {
	  $.post(root + "/GetChildren/" + (!!parentId ? parentId : 0))
		.then(function (response) {
		    for (var i = 0; i < response.length; i++) {
			  var item = response[i];
			  $("<li />")
				.addClass("hierarchy-item")
				.attr("data-id", item.SeriesId)
				.append("<a href='javascript:void(0)'><span class='state-icon glyphicon glyphicon-chevron-right'></span>" + item.Description + "</a>")
				.appendTo(element);
		    }
		});
    }

    var initializeRoot = function () {
	  getChildren($("#hierarchyRoot"), 0);
    }

    $("#hierarchyRoot").on("click", "li.hierarchy-item", function (item) {
	  var closestListItem = $(item.target).closest("li.hierarchy-item");
	  var id = closestListItem.attr("data-id");
	  $(item).remove("ul");

	  var element = $("<ul />");
	  element.appendTo(closestListItem);

	  getChildren(element, id);
    });

    initializeRoot();
});