<?php
class OperationCode {
  //�����û��������뷵��ҵ����֤��
  //userSignature ������������û��ĵ绰���룬���߻��պ�
  //type 1��ʾmd5���ܣ�type 2��ʾsha1����
  public function GenerateOperationCode($userSignature, $type){
      $ret = ''; //��ʼ������ֵ
      
      if ($type == 1) {
          $ret = md5($userSignature);
      }
      else if ($type == 2) {
          $ret = sha1($userSignature);
      }
      
      //������֤����Ϣ��ʱ����Ϣ
      $info = new CodeInformation();
      $info->operationCode = $ret;
      $info->genarationTime = time();
      //session_start();
      $_SESSION[$userSignature] = $info;
      
      return $ret;
  }
  
  //��֤�ͻ����ṩ����֤���Ƿ���ȷ
  //userSignature �û���������
  //time ��֤�����Чʱ�䣬����Ϊ��λ
  public function ValidateOperationCode($userSignature, $time){
      $ret = false;  //��ʼ������ֵ

      //�ж��û���֤��Ϣ�Ƿ����
      if (isset($_SESSION[$userSignature])) {
          //ȡ���û���֤��Ϣ
          $info = $_SESSION[$userSignature];
          
          //�ж��Ƿ�ʱ
          if (time() - $info->genarationTime < $time) {
              //�ж���֤���Ƿ�һ��
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


