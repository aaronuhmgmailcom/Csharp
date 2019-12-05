//document.write("<scri"+"pt type='text/javascript' src='js/jquery-1.5.2.min.js'></scr"+"ipt>"); 
// JavaScript Document
/*
*date: 20110415
*author: Jian Wu
*/
//hover事件调度 鼠标经过时 改变背景色,弹出本行的菜单
/*param(id:事件的对象id，
		strCss:CSS类名，鼠标移上去的样式)
		icon 菜单图标
/*
/*具体使用方法示例
<script>
$(function(){
	showShortMenuDown('liMenu','className',"imgId");
	})
</script>
*/
function showShortMenuDown(id,hoverClass,icon,speed)
{
  $("#"+id).hover(function(){
	$(this).addClass(hoverClass);
    $(this).children("ul").slideDown(speed);
	if(icon!=''){
		$("#"+icon).show();
	}
  },function(){
    $(this).children("ul").slideUp(speed);
	$(this).removeClass(hoverClass);
	if(icon!=''){
		$("#"+icon).hide();
	}
  })
}
