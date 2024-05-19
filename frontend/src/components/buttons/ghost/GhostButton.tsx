import BaseButton, { BaseButtonProps } from '../base/BaseButton'
import styles from './GhostButton.module.scss'

interface GhostButtonProps extends BaseButtonProps {

}

const GhostButton = (props: GhostButtonProps) => {
  return (
    <BaseButton {...props} className={`${styles.ghost} ${props.className}`} />
  )
}

export default GhostButton
