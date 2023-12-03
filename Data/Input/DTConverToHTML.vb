' HTML 테이블 시작
Dim htmlString As New System.Text.StringBuilder()
htmlString.Append("<table border='1' cellpadding='0' cellspacing='0' width='100%' >")

' 헤더 영역 시작
htmlString.Append("<thead style='text-align:center; font-weight:bold; background-color:#F3F4F6; height:35px;'>")
htmlString.Append("<tr>")
For Each column As DataColumn In dtResult.Columns
    htmlString.Append("<th style='width:100px;'>" + column.ColumnName + "</th>")
Next
htmlString.Append("</tr>")
htmlString.Append("</thead>")
' 헤더 영역 끝

htmlString.Append("<tbody>")
For Each row As DataRow In dtResult.Rows
    htmlString.Append("<tr>")
    For Each col As Object In row.ItemArray
        ' 줄 바꿈 문자를 <br>로 대체
        Dim cellValue As String = col.ToString().Replace(vbCrLf, "<br>").Replace(vbLf, "<br>").Replace(vbCr, "<br>")
        htmlString.Append("<td style='text-align:left; width:100px;'>" + cellValue + "</td>")
    Next
    htmlString.Append("</tr>")
Next
htmlString.Append("</tbody>")
' 데이터 영역 끝

' HTML 테이블 끝
htmlString.Append("</table>")

' 최종 HTML 문자열 반환
strHTML = htmlString.ToString()

' 결과를 로그에 출력 (확인을 위한 용도)
System.Diagnostics.Debug.WriteLine(strHTML)