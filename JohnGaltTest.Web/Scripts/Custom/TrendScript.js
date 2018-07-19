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
				.append("<a href='javascript:void(0)'><span class='state-icon glyphicon glyphicon-stop'></span>" + item.Description + "</a>")
				.appendTo(element);
		    }
		});
    }

    var getChartData = function (id) {
	  $.post(root + "/GetObservations/" + id)
		.then(function (response) {
		    renderChart(response);
		});
    }

    var renderChart = function (data) {
	  var tbody = $("#tableContent");
	  tbody.html("");

	  for (var i in data) {
		var item = data[i];

		var row = $("<tr />");

		$("<td />").html(item.Period).appendTo(row);
		$("<td />").html(item.Sales).appendTo(row);
		$("<td />").html(item.Demand).appendTo(row);
		$("<td />").html(item.Supply).appendTo(row);

		row.appendTo(tbody);
	  }
    }

    var initializeRoot = function () {
	  getChildren($("#hierarchyRoot"), 0);
    }

    $("#hierarchyRoot").on("click", "li.hierarchy-item", function (item) {
	  var closestListItem = $(item.target).closest("li.hierarchy-item");
	  var id = closestListItem.attr("data-id");

	  getChartData(id);

	  if (closestListItem.hasClass("open")) {
		closestListItem.removeClass("open")
		    .find("ul:first")
		    .addClass("hidden");
	  }
	  else {
		if ($(closestListItem).children("ul").length > 0) {
		    $(closestListItem).addClass("open").find("ul:first").removeClass("hidden");
		    item.stopPropagation();
		    return;
		}
		$(item.target).remove("ul");

		var element = $("<ul />");
		element.appendTo(closestListItem);

		getChildren(element, id);

		closestListItem.addClass("open").find("ul:first").attr("data-loaded", true);
	  }

	  item.stopPropagation();
    });

    initializeRoot();
});