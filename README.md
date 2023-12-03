### Documentation is included in the Documentation folder ###
[과제: 의약품 안전나라]
1. 의약품 안전나라>고시/공고/알림> 행정처분 조회 접속
2. 품목구분 및 조회 기간 설정 (품목구분:의약품 등, 전월 1일 ~ 당월 마지막일)
3. 템플릿 파일의 양식에 맞게 추출한 전체 DT’ 를 당월시트 에 입력
4. 이슈사항시트 의 내용 중 처분 일자가 당월인 것만 필터링 하여 당월이슈 시트 에 입력
5. 결과 파일을 첨부하여 양식대로 메일 발송

[사전작업]
- TransactionItem을 Queue에서 DataRow로 변경
- GetTransactionData workflow에서 Get transaction Item 커맨드아웃 처리
- Process Transaction > Set Transaction Status에서 각 예외처리의 Queue상태변경 부분 커맨드아웃 처리

[작업내용]
- 의약품 안전나라>고시/공고/알림> 행정처분 접속, 조회기간 입력, 조회결과 데이터스크래핑
- 조회결과 데이터스크래핑으로 얻은 URL정보로 처분 상세정보페이지 이동
- 처분 상세정보페이지에서 데이터추출
- 추출한 데이터 키워드 필터링, 당월 기간조건 필터링 하여 각각 데이터테이블 저장
- Temp폴더의 양식파일 복사 후 추출 및 필터링한 데이터 입력하여 Output폴더에 저장
- 보고대상자에게 OutPut폴더의 결과 파일 첨부하여 메일발송

[Config파일]
- strURL : 의약품 안전나라>고시/공고/알림> 행정처분 조회 페이지
- strResultFolderPath : 결과파일저장경로
- strTempPath : 양식파일폴더경로
- strTempFile : 양식파일명
- strAccount : 아웃룩 계정
- strMailTo : 받는사람
- strMailSubject : 메일 제목
- strMailBody : 당월이슈사항이 1건 이상일 때 메일내용 (html태그 포함)
- strMailBodyZero : 당월이슈사항이 0건일 때 메일내용

* 작업파일폴더: MyWork

### REFrameWork Template ###
**Robotic Enterprise Framework**


### How It Works ###

1. **INITIALIZE PROCESS**
[초기화]
- Kill Process (엑셀, 크롬)
- 결과파일폴더 초기화 
   Invoke: 
MyWork/PathCheck.xaml
- 의약품안전나라 접속 (Open Browser)
- dt_TransactionData 설정 
   Invoke: MyWork/GetData.xaml
- 처분상세정보 담을 datatable 생성

2. **GET TRANSACTION DATA**
[Transaction Data설정]
- Get Transaction Data : GetData.xaml에서 
스크래핑한 datarow 수 만큼 반복

3. **PROCESS TRANSACTION**
[데이터추출 및 처리]
- 행정처분정보상세페이지 접속
- 업체명, 처분일자, 위반내용, 처분사항 추출
- 추출한 데이터 Init단계에서 생성한 datatable에 입력

4. **END PROCESS**
[종료처리]
- 브라우저 닫기 close tab 
- 행정처분상세정보 데이터 필터링, 결과파일저장, 보고메일전송
invoke: MyWork/FilteredData_SendMail.xaml


### For New Project ###

1. Check the Config.xlsx file and add/customize any required fields and values
2. Implement InitiAllApplications.xaml and CloseAllApplicatoins.xaml workflows, linking them in the Config.xlsx fields
3. Implement GetTransactionData.xaml and SetTransactionStatus.xaml according to the transaction type being used (Orchestrator queues by default)
4. Implement Process.xaml workflow and invoke other workflows related to the process being automated
