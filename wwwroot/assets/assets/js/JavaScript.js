$(document).ready(function () {

var base_url = 'index-2.html';
$('.captcha-refresh').click(function (event) {
	event.preventDefault();
	$('.captcha').attr('src', base_url + 'home/captcha?' + Math.random());
	/*$.get(base_url+'home/captcha',function(res){
		$('#captcha').attr('src',res);
	});*/
});

	$('.bxslider').bxSlider({
		auto: true,
		speed: 500,
	});

	$('.bxslider1').bxSlider({
		auto: true,
		speed: 500,
	});

	$('.bxslider2').bxSlider({
		minSlides: 1,
		maxSlides: 5,
		slideWidth: 205,
		slideMargin: 28.7,
		moveSlides: 1
	});

	$('#tab').tabify();

jQuery(".accordion").accordion();

	$('.vc').keyup(function (e) {
		if ($(this).val().length == $(this).attr("maxlength")) {
			$(this).next().focus();
		}
		if (e.keyCode == 8) {
			if ($(this).val().length == 0) {
				$(this).prev().focus();
			}
		}
	});



function encryptPass() {
	var password = $("input[name=password]").val();
	$("input[name=password2]").val(password);
	var encrypted = SHA1(password);
	$("input[name=password]").val(encrypted);
}

function encryptPassDept() {
	var password = $("input[name=dp_password]").val();
	var encrypted = SHA1(password);
	$("input[name=dp_password]").val(encrypted);
}

function myFunction() {
	var vc1, vc2, vc3, vc4, type, text, text1;
	document.getElementById("demo1").innerHTML = "";
	document.getElementById("demo").innerHTML = "";

	// Get the value of the input field with id="numb"
	vc1 = document.getElementById("vc1").value;
	vc2 = document.getElementById("vc2").value;
	vc3 = document.getElementById("vc3").value;
	vc4 = document.getElementById("vc4").value;
	type = document.getElementById("act_type").value;
	// If x is Not a Number or less than one or greater than 10
	if (type == "") {
		text1 = "Please select the Licence type";
		document.getElementById("demo1").innerHTML = text1;
	} else if (vc1 == '' || vc2 == '' || vc3 == '' || vc4 == '') {
		text = "Please enter a valid 16 digit code";
		document.getElementById("demo").innerHTML = text;
	} else {
		document.getElementById("lic_frm").submit();
	}


}
$('.marquee').marquee({
	//speed in milliseconds of the marquee
	duration: 15000,
	//gap in pixels between the tickers
	gap: 50,
	//time in milliseconds before the marquee will start animating
	delayBeforeStart: 0,
	//'left' or 'right'
	direction: 'left',
	//true or false - should the marquee be duplicated to show an effect of continues flow
	duplicated: false,
	pauseOnHover: true
});




	$('.captcha-refresh').on('click', function () {
		$.get('home/reloadCaptcha.html', function (data) {
			$('.captImg').html(data);
		});
	});
});