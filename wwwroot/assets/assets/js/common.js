$(document).ready(function(){
	/* $('.bxslider').bxSlider({
		auto: true
	});
	
	
	$('.bxslider1').bxSlider({
	}); */
	
	
	
//	jQuery('#tab').tabify();
	
	
	/* $('.bxslider2').bxSlider({
		minSlides: 1,
		maxSlides: 5,
		slideWidth: 205,
		slideMargin: 28.7,
		moveSlides: 1
	}); */
	
	//jQuery(".accordion").accordion();
	
	
	
	$(function(){
		$('.scrollbar').slimScroll({
			height: '225px'
		});
	});
	
	$(".main-user").click(function(e){
            e.stopPropagation();
            $(".options").toggle();
	});
	$(".options").on("click", function (e) {
            e.stopPropagation();
        });
        $(document).on("click", function () {
            $(".options").hide();
        });	
	
	$(document).ready(function () {
		$('.hidden-div').hide();
		$(".radio1").change(function () { //use change event
			if (this.value == "hello") { //check value if it is domicilio
				$('.hidden-div').show(500); //than show
				} else {
				$('.hidden-div').hide(500); //else hide
			}
		});
	});
	
	$(document).ready(function () {
		$('.hidden-div1').hide();
		$(".radio").change(function () { //use change event
			if (this.value == "hello") { //check value if it is domicilio
				$('.hidden-div1').show(500); //than show
				} else {
				$('.hidden-div1').hide(500); //else hide
			}
		});
		
		$('#form_faq_submit').click(function(){
var content=$('.srch_input').attr("value")
//console.log(content);
 var search = new RegExp('^[_A-z0-9]*((-|\s)*[_A-z0-9])*$');
        if (search.test(content)) {
        //console.log('pass');	
        $('#faq_form_action').submit();
            
        }
        else{

        	console.log('Inncorrect content');
        }
	});
	
	
	});
	
	$(function(){
		
		/*-------------------------------
			
			GENERAL EXAMPLES
			
		-------------------------------*/
		
		// Default usage
		$('.default_popup').popup();
		$('.jquery_popup').popup({
			content		: $('#inline')
		});
		
	});
	
	
	
	
	
	
	
	
	
	
	
});