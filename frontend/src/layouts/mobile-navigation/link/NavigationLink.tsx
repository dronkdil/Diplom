"use client"
import Link from "next/link"
import { usePathname } from "next/navigation"
import styles from "./NavigationLink.module.scss"

export type NavigationLinkProps = {
    icon: React.ReactElement
    href: string
}

const NavigationLink = ({icon, href}: NavigationLinkProps) => {
  const pathname = usePathname()
  const active = href === pathname
  
  return (
    <Link href={href} className={`${styles.link} ${active && styles['link--active']}`}>
      {icon}
    </Link>
  )
}

export default NavigationLink
