import { DefaultLink, GhostLink } from "@/components/links"
import Logo from "@/components/logo/Logo"
import { Routes } from "@/lib/routes.constants"
import styles from "./Header.module.scss"

const Header = () => {
  return (
    <div className={styles.header}>
      <Logo />
      <div className={styles.header__auth}>
        <GhostLink href={Routes.Login}>Війти</GhostLink>
        <DefaultLink href={Routes.Registration}>Зареєструватись</DefaultLink>
      </div>
    </div>
  )
}

export default Header
