import BaseButton, { BaseButtonProps } from '../base/BaseButton'
import styles from './IconButton.module.scss'

interface IconButtonProps extends BaseButtonProps {

}

const IconButton = (props: IconButtonProps) => {
  return (
    <BaseButton {...props} className={`${styles.icon} ${props.className}`} />
  )
}

export default IconButton
