import styles from "./NotificationItem.module.scss"

export type NotificationItemProps = {
    title: string
    description: string
    icon: React.ReactElement
    buttons: React.ReactElement | React.ReactElement[]
}

const NotificationItem = ({title, description, icon, buttons}: NotificationItemProps) => {
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
            <div className={styles.notification__buttons}>
                {buttons}
            </div>
      </div>
  )
}

export default NotificationItem
