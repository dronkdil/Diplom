import { Routes } from "@/lib/routes.constants"
import { BookIcon, HomeIcon, TicketCheckIcon, UserRoundIcon } from "lucide-react"
import styles from "./MobileNavigation.module.scss"
import NavigationLink from "./link/NavigationLink"

const MobileNavigation = () => {
  return (
    <div className={styles.wrapper}>
      <div className={styles.navigation}>
        <NavigationLink icon={<HomeIcon />} href={Routes.Courses} />
        <NavigationLink icon={<BookIcon />} href={Routes.Profile.Courses} />
        <NavigationLink icon={<TicketCheckIcon />} href={Routes.Profile.Certificates} />
        <NavigationLink icon={<UserRoundIcon />} href={Routes.Profile.MyData} />
      </div>
    </div>
  )
}

export default MobileNavigation
