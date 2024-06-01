import Link, { LinkProps } from 'next/link'
import styles from './BaseLink.module.scss'

export type BaseLinkProps = 
  Omit<React.AnchorHTMLAttributes<HTMLAnchorElement>, keyof LinkProps> 
  & LinkProps 
  & React.RefAttributes<HTMLAnchorElement>
  & {
    children?: React.ReactNode
  }

const BaseLink = ({children, className, href, ...props}: BaseLinkProps) => {
  return (
    <Link {...props} href={href} className={`${styles.base} ${className}`}>
      {children}
    </Link>
  )
}

export default BaseLink

