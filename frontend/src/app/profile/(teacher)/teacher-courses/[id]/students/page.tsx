"use client"
import { StudentService } from "@/api/users/student/student.service"
import { StudentDataType } from "@/api/users/student/types/student-data.type"
import Avatar from "@/components/avatar/Avatar"
import { DefaultLink } from "@/components/links"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { Routes } from "@/lib/routes.constants"
import { useParams } from "next/navigation"
import styles from "./Students.module.scss"

const StudentsPage = () => {
    const {id} = useParams()
    const {data} = useTypedQuery<StudentDataType[]>({
        name: `get-students-by-course-for-teacher-${id}`,
        request: () => StudentService.getByCourse(Number(id))
    })

  return (
    <div className={styles.students}>
      <div className={styles.students__header}>
        <DefaultLink className="inline" href={Routes.Teacher.Course(id)}>Повернутись</ DefaultLink>  
      </div>

      {data?.length == 0 && <span className={styles.students__empty}>Наразі на цьому курсі немає студентів</span>}
      <div className={styles.students__content}>
        {data?.map(o => <div key={o.id} className={styles.students__item}>
          <div>
            <Avatar 
              isSmall 
              src={o.avatarUrl} 
              firstName={o.firstName}
              lastName={o.lastName}
            />
          </div>
          <div>
            <div>{o.displayName}</div>
            <div>{o.email}</div>
            <div>{o.birthday}</div>
            <div>{o.educationalStatus}</div>
          </div>
        </div>)}
      </div>
    </div>
  )
}

export default StudentsPage
