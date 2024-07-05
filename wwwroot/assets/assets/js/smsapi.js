/****OTP code start*****/	
 function updatealldata()
 {
	var otp_num = $("#otp_val").val();
	if(otp_num == ""){
		$("#label_9").css("display","block");
		$("#label_10").css("display","none");
		$("#label_11").css("display","none");
		return false;
	}
	$.ajax({
		type:"POST",
		async: false,
		url: base_url+"Smsotp/validateOTP/"+otp_num,
		success:function(OTP){
			
			if(OTP == 'Expire'){
				$("#label_11").css("display","block");
				$("#label_10").css("display","none");
				$("#label_9").css("display","none");
				returnVal = false;
				} else if(otp_num == OTP){
					
				$("#label_11").css("display","none");
				$("#label_10").css("display","none");
				$("#label_9").css("display","none");
				var x = confirm("Are you sure you want to submit?");
					if (x){
						returnVal = true;
					}else{						
					returnVal = false;
				}
			 }else{
				$("#label_9").css("display","none");
				$("#label_10").css("display","block");
				$("#label_11").css("display","none");
				returnVal = false 
			 }
		  }
	   });
	   return returnVal;
	}
var time = 0;
var tid;
function getOut(){
		 time = time - 1;
		 if(time>0){
				$("#timeout").text(time);
		} else {
			clearInterval(tid);
		}
	}
function sendCode(){
	
	$("#label_11").css("display","none");
	$("#verify_button").hide();
	time = 60;
	tid = setInterval('getOut()',1000);
	 setTimeout(function() {
		$("#verify_button").show();
		$("#label_11").css("display","block");
		$("#label_10").css("display","none");
		$("#label_9").css("display","none");
	  }, 60000);
	$("#verify_status_msg").css("display","block");
	$.ajax({ 
		type:'POST',
		url:base_url+"Smsotp/smsApi",          
		data:{
			phone:$("#mobile_number").val(),
			code:$("#otp_num").val()
			},
			datatype : 'html',
			success:function(value){
				$('#verify_status_msg').delay(60000).fadeOut('slow');
			}
		});
}
/****OTP code End *****/	
