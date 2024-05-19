import { Url } from 'next/dist/shared/lib/router/router'
import Link from 'next/link'
import styles from './BaseLink.module.scss'

export type BaseLinkProps = React.RefAttributes<HTMLAnchorElement> & {
    children: any
    className?: React.ReactNode
    href: Url
}

const BaseLink = ({children, className, href, ...props}: BaseLinkProps) => {
  return (
    <Link {...props} href={href} className={`${styles.base} ${className}`}>
      {children}
    </Link>
  )
}

export default BaseLink

