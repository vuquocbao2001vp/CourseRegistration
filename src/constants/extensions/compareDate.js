export default function isMatchDate(date1, date2) {
  const day1 = parseInt(date1.charAt(4));
  const day2 = parseInt(date2.charAt(4));

  if (day1 === day2) {
    const regex = /\(([^)]+)\)/g; // Biểu thức chính quy để lấy giá trị trong dấu ngoặc đơn
    const matches1 = date1.match(regex); // Lấy ra một mảng chứa các giá trị trong dấu ngoặc đơn
    const values1 = matches1[0].split("-"); // Tách chuỗi bên trong dấu ngoặc đơn thành các giá trị bằng dấu gạch ngang

    const startPeriod1 = parseInt(values1[0].trim().substring(5));
    const endPeriod1 = parseInt(values1[1]);

    const matches2 = date2.match(regex); // Lấy ra một mảng chứa các giá trị trong dấu ngoặc đơn
    const values2 = matches2[0].split("-"); // Tách chuỗi bên trong dấu ngoặc đơn thành các giá trị bằng dấu gạch ngang

    const startPeriod2 = parseInt(values2[0].trim().substring(5));
    const endPeriod2 = parseInt(values2[1]);
    if (
      startPeriod1 === startPeriod2 ||
      endPeriod1 === endPeriod2 ||
      startPeriod1 === endPeriod2 ||
      endPeriod1 === startPeriod2
    )
      return true;
    if (
      startPeriod1 < startPeriod2 &&
      (endPeriod1 > endPeriod2 ||
        (endPeriod1 > startPeriod2 && endPeriod1 < endPeriod2))
    )
      return true;
    if (
      startPeriod2 < startPeriod1 &&
      (endPeriod2 > endPeriod1 ||
        (endPeriod2 > startPeriod1 && endPeriod2 < endPeriod1))
    )
      return true;
  }
  return false;
}
