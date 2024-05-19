"use client"
import { GhostButton } from "@/components/buttons"
import { useReduxActions } from "@/hooks/useReduxActions"
import { SunIcon } from "lucide-react"
import { useEffect } from "react"
import NotificationItem from "../../components/notification/NotificationItem"
import styles from "./Notifications.module.scss"

const NotificationsPage = () => {
  const {setProfileTitle} = useReduxActions()
  useEffect(() => { setProfileTitle("Повідомлення") }, [])

  return (
    <>
      <div className={styles.notifications__content}>
        <NotificationItem
          icon={<SunIcon />}
          title={"Вітаю!!!"}
          description={"Ви закінчили курс на пітоні по python"}
          buttons={<GhostButton>Завантажити сертифікат</GhostButton>}
        />
        <NotificationItem
          icon={<SunIcon />}
          title={"Вітаю!!!"}
          description={"Ви закінчили курс на пітоні по python"}
          buttons={<GhostButton>Завантажити сертифікат</GhostButton>}
        />
      </div>
    </>
  )
}

export default NotificationsPage
