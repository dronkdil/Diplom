import { cn } from '@/lib/utils'
import { LoaderCircleIcon } from 'lucide-react'
import { ButtonHTMLAttributes } from 'react'
import styles from './BaseButton.module.scss'

export interface BaseButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
    isLoading?: boolean
    children: any
}

const BaseButton = ({children, className, isLoading, ...props}: BaseButtonProps) => {
  return (
    <button {...props} className={cn(styles.base, className)}>
      <div className={styles.base__content}>
        {isLoading 
          ? <LoaderCircleIcon className="animate-spin" />
          : children
        }
      </div>
    </button>
  )
}

export default BaseButton

