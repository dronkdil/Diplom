import { LoaderCircleIcon } from 'lucide-react'
import { ButtonHTMLAttributes } from 'react'
import styles from './BaseButton.module.scss'

export interface BaseButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
    isLoading?: boolean
    children: any
}

const BaseButton = ({children, className, isLoading, ...props}: BaseButtonProps) => {
  return (
    <button {...props} className={`${styles.base} ${className}`}>
      {isLoading 
        ? <LoaderCircleIcon className="animate-spin" />
        : children
      }
    </button>
  )
}

export default BaseButton

