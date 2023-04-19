<template>
  <div class="home">
    <div class="header font-semibold">Thông báo</div>
    <div class="noti-flex flex">
      <div class="dot"></div>
      <div class="noti-text">Thời gian đăng ký học trực tuyến: từ 25/05/2024 - 28/04/2024</div>
    </div>
    <div class="noti-flex flex">
      <div class="dot"></div>
      <div>
        <div class="noti-text">Sinh viên đăng ký môn học theo đúng chương trình, ngành học của mình</div>
        <div class="noti-text">Sinh viên tra cứu chương trình đào tạo tại: <a href="https://uet.vnu.edu.vn/chuong-trinh-dao-tao/">https://uet.vnu.edu.vn/chuong-trinh-dao-tao/</a></div>
      </div>
    </div>
    <div class="noti-flex flex">
      <div class="dot"></div>
      <div class="noti-text">Sinh viên theo dõi thông báo mới nhất tại cổng thông tin điện tử của trường: <a href="https://uet.vnu.edu.vn/category/tin-tuc/tin-sinh-vien/">https://uet.vnu.edu.vn/category/tin-tuc/tin-sinh-vien/</a></div>
    </div>
    <div class="header font-semibold mgt-24">Hướng dẫn</div>
    <div class="noti-flex flex">
      <div class="dot"></div>
      <a href="https://www.youtube.com/channel/UCGweoAectHnrvkiQtghsTOg" class="noti-text">Video hướng dẫn sử dụng cổng thông tin đăng ký học</a>
    </div>
    <div class="noti-flex flex">
      <div class="dot"></div>
      <a href="https://sinhvienvnu.edu.vn/video/ky-nang-hoc-dai-hoc-hieu-qua" class="noti-text">Kĩ năng học tập hiệu quả ở bậc Đại học</a>
    </div>
    <div class="noti-flex flex">
      <div class="dot"></div>
      <a href="https://www.youtube.com/watch?v=ZabYHps4huI" class="noti-text">Hướng dẫn đăng ký học bổng</a>
    </div>
    <div class="contact font-semibold">Sinh viên có thắc mắc vui lòng liên hệ với phòng đào tạo qua email: pdt@vnu.edu.vn hoặc liên hệ trực tiếp tại Phòng công tác Sinh viên 203-E3</div>
  </div>
</template>

<script>
export default {

}
</script>

<style scoped>
.home {
  width: 100%;
  height: 100%;
  padding: 16px 0;
  box-sizing: border-box;
}
.header{
  font-size: 24px;
  margin-bottom: 12px;
}
.noti-flex {
  align-items: baseline;
}
.dot {
  width: 8px;
  height: 8px;
  min-width: 8px;
  min-height: 8px;
  border-radius: 50%;
  background-color: #666;
  margin: 0 16px;
}
.noti-text{
  font-size: 16px;
  padding: 6px 0;
}
.mgt-24{
  margin-top: 24px;
}
.contact {
  margin: 24px 0;
  font-size: 18px;
}
</style>