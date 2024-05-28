import { StudentService } from "@/api/users/student/student.service"
import { AccentButton, DefaultButton } from "@/components/buttons"
import AccentLink from "@/components/links/accent/AccentLink"
import Skeleton from "@/components/skeleton/Skeleton"
import { useTypedMutation } from "@/hooks/useTypedMutation"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { getAuthenticated } from "@/lib/redux/slices/AuthenticationSlice"
import { getUserData } from "@/lib/redux/slices/UserSlice"
import { Routes } from "@/lib/routes.constants"
import { useSelector } from "react-redux"
import styles from "../../Course.module.scss"

export type CourseHeaderType = {
    courseId: number
}

const CourseHeader = ({courseId}: CourseHeaderType) => {
    const user = useSelector(getUserData)
    const isAuthenticated = useSelector(getAuthenticated)
    
    const {data: isJoinedCourse, isPending: joinedCoursePending, refetch: joinedCourseRefetch, setData: setJoinedCourse} = useTypedQuery<boolean>({
        name: `already-joined-course-${courseId}`,
        request: () => StudentService.alreadyJoinedCourse(Number(courseId)),
        conditional: () => user != undefined && user.role == "Student"
    })

    const {mutateAsync: joinCourse, isPending: joinCoursePending} = useTypedMutation({
        name: `joined-to-course-${courseId}`,
        request: () => StudentService.joinCourse(Number(courseId)),
        onSuccess: () => {
            setJoinedCourse(true)
            joinedCourseRefetch()
        }
    })

    const {mutateAsync: leaveCourse, isPending: leaveCoursePending} = useTypedMutation({
        name: `leave-to-course-${courseId}`,
        request: () => StudentService.leaveCourse(Number(courseId)),
        onSuccess: () => {
            setJoinedCourse(false)
            joinedCourseRefetch()
        }
    })

    if (isAuthenticated && user?.role != "Student")
        return <></>

    return (
        <>
            <div className={styles["course__modules-header"]}>
                <span>Безкоштовний курс</span>

                {isAuthenticated && <>
                    {joinedCoursePending 
                        ? <Skeleton className="w-[150px] h-[40px]" />
                        : isJoinedCourse 
                            ? <DefaultButton isLoading={leaveCoursePending} onClick={() => leaveCourse()}>Покинути курс</DefaultButton>
                            : <AccentButton isLoading={joinCoursePending} onClick={() => joinCourse()}>Доєднатись до курсу</AccentButton>
                    }
                </>}

                {!isAuthenticated && <>
                    <AccentLink href={Routes.Login}>Доєднатись до курсу</AccentLink>
                </>}
            </div>
        </>
    )
}

export default CourseHeader
