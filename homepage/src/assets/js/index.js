
// anonymous function outside the global scope
$(document).ready(function () {

	$(document).ready(function () {
		$("body").css("display", "none");
		$("body").fadeIn(500);

		$("a").click(function (event) {
			event.preventDefault();
			linkLocation = this.href;
			$("body").fadeOut(100, redirectPage);
		});
	// func redirect to page !! To do - check if still in use!!
		function redirectPage() {
			window.location = linkLocation;
		}
	});
	
	//anonymous btn func
	var button = $("#Köpbutton");
	button.on("click", function () {
		console.log("1 vara lades till i varukorgen");
	});

	//popup-form func
	var $loginToggle = $("#loginToggle");
	var $popupForm = $(".popup-form");

	$loginToggle.on("click", function () {
		$popupForm.toggle();
	});
});