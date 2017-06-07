<?php
   if(isset($_FILES['image'])){
      $errors= array();
      $file_name = $_FILES['image']['name']; //the actual name of the uploaded file
	  $file_tmp =$_FILES['image']['tmp_name']; //the uploaded file in the temporary directory on the web server.
      $file_size =$_FILES['image']['size'];      
      $file_type=$_FILES['image']['type'];
      $file_ext=strtolower(end(explode('.',$_FILES['image']['name'])));
      
      $expensions= array("jpeg","jpg","png");
      
      if(in_array($file_ext,$expensions)=== false){
         $errors[]="extension not allowed, please choose a JPEG or PNG file.";
      }
      
      if($file_size > 2097152){
         $errors[]='File size must be excately 2 MB';
      }
      
      if(empty($errors)==true){
         move_uploaded_file($file_tmp,"images/".$file_name);
         echo "Success";
      }else{
         print_r($errors);
      }
   }
?>
<html>
   <body>
      <form action="" method="POST" enctype="multipart/form-data">
        <div>
            <label for="photo_title">Title</label>
            <input type="text" name="title" id="photo_title">
        </div>
        <div>
            <label for="photo_image">Image</label>
            <input type="file" name="image" id="photo_image">
        </div>
        <input type="submit" name="commit" value="Upload" data-disable-with="Upload">
      </form>
      
   </body>
</html>