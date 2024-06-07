import { NotificationType } from "@/api/users/notification/type/notification.type"
import styles from "./NotificationItem.module.scss"

export type NotificationItemProps = NotificationType & {
    icon: React.ReactElement
}

const NotificationItem = ({title, description, icon}: NotificationItemProps) => {
  return (
    <div className={styles.notification}>
           <div className={styles.notification__content}>
                <div  className={styles.notification__icon}>
                    {icon}
                </div>
                <div>
                    <h4 className={styles.notification__title}>{title}</h4>
                    <p className={styles.notification__description}>{description}</p>
                </div>
           </div>
      </div>
  )
}

export default NotificationItem
