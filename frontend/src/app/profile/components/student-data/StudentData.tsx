import { StudentService } from "@/api/users/student/student.service"
import { StudentDataType } from "@/api/users/student/types/student-data.type"
import Skeleton from "@/components/skeleton/Skeleton"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import styles from "./../../Profile.module.scss"

const StudentData = () => {
  const {data: studentData, isPending} = useTypedQuery<StudentDataType>({
    name: 'get-student-data',
    request: () => StudentService.getMyData(),
  })

  if (isPending)
    return <>
      <Skeleton className={styles.info__skeleton}></Skeleton>
      <Skeleton className={styles.info__skeleton}></Skeleton>
    </>

  return (
    <>
      <div className={styles.info__data}>{studentData?.educationalStatus}</div>
      <div className={styles.info__data}>{studentData?.birthday}</div>
    </>
  )
}

export default StudentData
