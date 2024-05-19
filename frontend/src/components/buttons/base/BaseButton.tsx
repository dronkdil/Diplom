import { ButtonHTMLAttributes } from 'react'
import styles from './BaseButton.module.scss'

export interface BaseButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
    isLoading?: boolean
    children: any
}

const BaseButton = ({children, className, ...props}: BaseButtonProps) => {
  return (
    <button {...props} className={`${styles.base} ${className}`}>
      {children}
    </button>
  )
}

export default BaseButton

