"use client"
import { NotificationService } from "@/api/users/notification/notification.service"
import { NotificationType } from "@/api/users/notification/type/notification.type"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useTypedQuery } from "@/hooks/useTypedQuery"
import { getUserData } from "@/lib/redux/slices/UserSlice"
import { SunIcon } from "lucide-react"
import { useEffect } from "react"
import { useSelector } from "react-redux"
import NotificationItem from "../../components/notification/NotificationItem"
import styles from "./Notifications.module.scss"

const NotificationsPage = () => {
  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle("Повідомлення") }, [])

  const user = useSelector(getUserData)

  const {data} = useTypedQuery<NotificationType[]>({
    name: `get-notifications`,
    request: () => NotificationService.getForUser(user.id)
  })

  return (
    <>
      <div className={styles.notifications__content}>

        {data?.length == 0 && <span className="text-white">У вас немає повідомлень</span>}

        {data?.map(o => <NotificationItem
          icon={<SunIcon />}
          {...o}
        />)}
      </div>
    </>
  )
}

export default NotificationsPage
