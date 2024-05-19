import styles from '@/components/buttons/ghost/GhostButton.module.scss'
import BaseButton, { BaseLinkProps } from '../base/BaseLink'

export type GhostLinkProps = BaseLinkProps

const GhostLink = (props: GhostLinkProps) => {
  return (
    <BaseButton {...props} className={`${styles.ghost} ${props.className}`} />
  )
}

export default GhostLink
