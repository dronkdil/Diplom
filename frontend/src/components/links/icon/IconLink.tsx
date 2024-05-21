import styles from '@/components/buttons/icon/IconButton.module.scss'
import BaseButton, { BaseLinkProps } from '../base/BaseLink'

export type IconLinkProps = BaseLinkProps

const IconLink = (props: IconLinkProps) => {
  return (
    <BaseButton {...props} className={`${styles.icon} ${props.className}`} />
  )
}

export default IconLink
