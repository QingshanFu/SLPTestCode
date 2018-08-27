<?php
class OperationCode {
  //根据用户的特征码返回业务验证码
  //userSignature 特征码可以是用户的电话号码，或者护照号
  //type 1表示md5加密，type 2表示sha1加密
  public function GenerateOperationCode($userSignature, $type){
      $ret = ''; //初始化返回值
      
      if ($type == 1) {
          $ret = md5($userSignature);
      }
      else if ($type == 2) {
          $ret = sha1($userSignature);
      }
      
      //保存验证码信息和时间信息
      $info = new CodeInformation();
      $info->operationCode = $ret;
      $info->genarationTime = time();
      //session_start();
      $_SESSION[$userSignature] = $info;
      
      return $ret;
  }
  
  //验证客户端提供的验证码是否正确
  //userSignature 用户的特征码
  //time 验证码的有效时间，以秒为单位
  public function ValidateOperationCode($userSignature, $time){
      $ret = false;  //初始化返回值

      //判断用户验证信息是否存在
      if (isset($_SESSION[$userSignature])) {
          //取得用户验证信息
          $info = $_SESSION[$userSignature];
          
          //判断是否超时
          if (time() - $info->genarationTime < $time) {
              //判断验证码是否一致
              if ($this->GenerateOperationCode($userSignature, 1) == $info->operationCode) {
                  $ret = true;
                  unset($_SESSION[$userSignature]);
              }
          }
      }
      
      return $ret;
  }
}

class CodeInformation {
    public $operationCode = '';
    public $genarationTime = 0;
}

$a = new OperationCode();
echo $a->GenerateOperationCode("13621396439",1);
echo "\r\n";
echo $a->ValidateOperationCode("13621396439",3)?'pass':'error';
?>


